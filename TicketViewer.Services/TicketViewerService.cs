using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            var ticketsResponse = await Model.Zendesk.ApiConstants.TicketsListAPI.SendHttpRequest(HttpMethod.Get);
            var ticketsList = ticketsResponse.Value
                                .FromJson<Model.Zendesk.TicketListViewModel>()
                                .tickets
                                .MapCollectionTo<Model.Zendesk.TicketViewModel, Ticket>();

            return ticketsList;
        }
    }
}
