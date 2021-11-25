using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TicketViewer.Common;
using TicketViewer.Model;

namespace TicketViewer.Services
{
    public class TicketViewerService : ITicketViewerService
    {
        public TicketViewerService()
        {
        }

        public async Task<TicketsPage> GetTicketsPage(string pageUrl = "")
        {
            // Using Offset Pagination
            pageUrl = string.IsNullOrEmpty(pageUrl) ? Model.Zendesk.ApiUrlConstants.TicketsListAPI : pageUrl;
            var ticketsListAPI = string.Format(pageUrl, DomainResolver.ZendeskSubdomainName);

            var ticketsResponse = await ticketsListAPI.SendHttpRequest(HttpMethod.Get);
            var ticketsPage = ticketsResponse.Value
                                    .FromJson<Model.Zendesk.TicketListViewModel>()
                                    .MapTo<TicketsPage>();

            var userIds = ticketsPage.Tickets.SelectMany(t => t.TicketUserIds).ToList();
            var users = await this.GetUsers(userIds);
            ticketsPage.Tickets.ForEach(ticket =>
            {
                ticket.TicketUsers = users.Where(u => ticket.TicketUserIds.Contains(u.Id)).ToList();
            });

            return ticketsPage;
        }

        public async Task<Ticket> GetTicketDetails(int ticketId)
        {
            var ticketsDetailsAPI = string.Format(
                Model.Zendesk.ApiUrlConstants.TicketDetailsAPI, 
                DomainResolver.ZendeskSubdomainName, 
                ticketId);

            var ticketResponse = await ticketsDetailsAPI.SendHttpRequest(HttpMethod.Get);
            var ticket = ticketResponse.Value
                                    .FromJson<Model.Zendesk.TicketDetailsViewModel>()
                                    .ticket
                                    .MapTo<Ticket>();

            ticket.TicketUsers = await this.GetUsers(ticket.TicketUserIds);

            return ticket;
        }

        public async Task<List<User>> GetUsers(List<long> userIds)
        {
            var usersAPI = string.Format(
                Model.Zendesk.ApiUrlConstants.UsersAPI, 
                DomainResolver.ZendeskSubdomainName, 
                string.Join(",", userIds));

            var usersResponse = await usersAPI.SendHttpRequest(HttpMethod.Get);
            var users = usersResponse.Value
                                    .FromJson<Model.Zendesk.UsersListViewModel>()
                                    .users
                                    .MapCollectionTo<Model.Zendesk.User, User>()
                                    .ToList();

            return users;
        }
    }
}
