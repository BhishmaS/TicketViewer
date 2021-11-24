using System.Collections.Generic;

namespace TicketViewer.Model
{
    public class TicketsPage
    {
        public TicketsPage()
        {
            this.Tickets = new List<Ticket>();
        }

        public List<Ticket> Tickets { get; set; }

        public int TotalTickets { get; set; }

        public string PreviousPage { get; set; }

        public string NextPage { get; set; }
    }
}
