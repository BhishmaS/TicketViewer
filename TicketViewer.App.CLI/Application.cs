using System;
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
            var tickets = await this.TicketViewerService.GetAllTickets();
            Console.WriteLine("Hello World!");
        }
    }
}
