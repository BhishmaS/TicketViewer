using System.Collections.Generic;
using TicketViewer.Model;

namespace TicketViewer.App.Web.Models
{
    public class TicketsPageViewModel
    {
        public TicketsPageViewModel()
        {
            this.Tickets = new List<Ticket>();
        }

        public List<Ticket> Tickets { get; set; }

        public int TotalTickets { get; set; }

        public string PreviousPage { get; set; }

        public string NextPage { get; set; }
    }
}
