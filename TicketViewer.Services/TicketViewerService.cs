using System;
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

        public async Task<TicketsPage> GetTicketsPage(string pageUrl = "", int pageSize = 25)
        {
            try
            {
                // Using Offset Pagination
                var ticketsListAPI = string.IsNullOrEmpty(pageUrl)
                    ? string.Format(Model.Zendesk.ApiUrlConstants.TicketsListAPI, DomainResolver.ZendeskSubdomainName, pageSize)
                    : pageUrl;

                //// static code.. need to be in separate service 
                //// for example: used for unit tests where this static api calls should not be triggred
                //// need to pass mock data service over there
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
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching tickets", ex);
            }
        }

        public async Task<Ticket> GetTicketDetails(long ticketId)
        {
            try
            {
                if (ticketId > 0)
                {
                    var ticketsDetailsAPI = string.Format(Model.Zendesk.ApiUrlConstants.TicketDetailsAPI, 
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

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching ticket details", ex);
            }
        }

        public async Task<List<User>> GetUsers(List<long> userIds)
        {
            try
            {
                if (userIds.Count > 0)
                {
                    var usersAPI = string.Format(Model.Zendesk.ApiUrlConstants.UsersAPI,
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

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching users", ex);
            }
        }
    }
}
