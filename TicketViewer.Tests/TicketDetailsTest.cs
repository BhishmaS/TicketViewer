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
        public async Task TestTicketsList()
        {
            var ticketsDetails = await this.ticketViewerService.GetTicketDetails(1);

            Assert.NotNull(ticketsDetails);
        }
    }
}
