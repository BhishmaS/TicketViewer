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

            return ticketsPage;
        }

        public async Task<Ticket> GetTicketDetails(int ticketId)
        {
            var ticketsDetailsAPI = string.Format(Model.Zendesk.ApiUrlConstants.TicketDetailsAPI, DomainResolver.ZendeskSubdomainName, ticketId);

            var ticketResponse = await ticketsDetailsAPI.SendHttpRequest(HttpMethod.Get);
            var ticket = ticketResponse.Value
                                    .FromJson<Model.Zendesk.TicketDetailsViewModel>()
                                    .ticket
                                    .MapTo<Ticket>();

            return ticket;
        }
    }
}
