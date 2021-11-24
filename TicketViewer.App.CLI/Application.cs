using System;
using System.Linq;
using System.Threading.Tasks;
using TicketViewer.Services;

namespace TicketViewer.App.CLI
{
    public class Application
    {
        public ITicketViewerService TicketViewerService { get; set; }

        public Application()
        {
            this.TicketViewerService = new TicketViewerService(); // need to update this resolving using dependency injection
        }

        public async Task Run()
        {
            var ticketsPage = await this.TicketViewerService.GetTicketsPage();

            Console.WriteLine("Tickets in Zendesk");
            foreach (var ticket in ticketsPage.Tickets.Select((value, index) => new { index, value }))
            {
                Console.WriteLine("\nTicket " + (ticket.index + 1));
                Console.WriteLine("Ticket Id: " + ticket.value.Id);
                Console.WriteLine("Requester Id: " + ticket.value.RequesterId);
                Console.WriteLine("Assignee Id: " + ticket.value.AssigneeId);
                Console.WriteLine("Subject: " + ticket.value.Subject);
                Console.WriteLine("Description: " + ticket.value.Description);
                Console.WriteLine("Tags: " + string.Join(", ", ticket.value.Tags));
                Console.WriteLine("Status: " + ticket.value.Status);
                Console.WriteLine("Created On: " + ticket.value.CreatedOn.ToString());
                Console.WriteLine("Updated On: " + ticket.value.UpdatedOn.ToString());
            }
        }
    }
}
