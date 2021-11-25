using System.Linq;
using System.Threading.Tasks;
using TicketViewer.Services;
using Xunit;

namespace TicketViewer.Tests
{
    public class TicketDetailsTest : BaseTest
    {
        private readonly TicketViewerService ticketViewerService;

        public TicketDetailsTest()
        {
            this.ticketViewerService = new TicketViewerService();
        }

        [Fact]
        public async Task TestDetails_Negative_Id()
        {
            var ticketsDetails = await this.ticketViewerService.GetTicketDetails(-1);

            Assert.Null(ticketsDetails);
        }

        [Fact]
        public async Task TestDetails_Valid_Id()
        {
            var firstTicketsPage = await this.ticketViewerService.GetTicketsPage(string.Empty, 25);
            if (firstTicketsPage.Tickets.Count > 0)
            {
                var firstTicket = firstTicketsPage.Tickets.FirstOrDefault();
                var ticketsDetails = await this.ticketViewerService.GetTicketDetails(firstTicket.Id);

                Assert.NotNull(ticketsDetails);
            }
        }
    }
}
