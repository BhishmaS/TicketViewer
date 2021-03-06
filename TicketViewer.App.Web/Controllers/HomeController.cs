using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TicketViewer.App.Web.Models;
using TicketViewer.Services;

namespace TicketViewer.App.Web.Controllers
{
    public class HomeController : Controller
    {
        public ITicketViewerService TicketViewerService { get; set; }

        public HomeController(ITicketViewerService ticketViewerService)  // dependency injection
        {
            this.TicketViewerService = ticketViewerService;
        }

        public async Task<IActionResult> Index(string pageUrl = "")
        {
            var ticketsPage = await this.TicketViewerService.GetTicketsPage(pageUrl);
            var ticketsPageView = new TicketsPageViewModel()
            {
                Tickets = ticketsPage.Tickets,
                TotalTickets = ticketsPage.TotalTickets,
                PreviousPage = ticketsPage.PreviousPage,
                NextPage = ticketsPage.NextPage,
            };

            return View(ticketsPageView);
        }

        public async Task<IActionResult> TicketDetails(long id)
        {
            var ticketDetails = await this.TicketViewerService.GetTicketDetails(id);
            var ticketDetailsView = new TicketDetailsViewModel()
            {
                Id = ticketDetails.Id,
                RequesterId = ticketDetails.RequesterId,
                Requester = ticketDetails.Requester,
                AssigneeId = ticketDetails.AssigneeId,
                Assignee = ticketDetails.Assignee,
                Subject = ticketDetails.Subject,
                Description = ticketDetails.Description,
                Type = ticketDetails.Type,
                Priority = ticketDetails.Priority,
                Tags = ticketDetails.Tags,
                Status = ticketDetails.Status,
                CreatedOn = ticketDetails.CreatedOn,
                UpdatedOn = ticketDetails.UpdatedOn,
            };

            return View(ticketDetailsView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var errorView = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Exception = exceptionHandlerPathFeature?.Error,
            };

            return View(errorView);
        }
    }
}
