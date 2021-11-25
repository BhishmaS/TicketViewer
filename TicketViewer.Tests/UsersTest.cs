using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketViewer.Services;
using Xunit;

namespace TicketViewer.Tests
{
    public class UsersTest : BaseTest
    {
        private readonly TicketViewerService ticketViewerService;

        public UsersTest()
        {
            this.ticketViewerService = new TicketViewerService();
        }

        [Fact]
        public async Task TestUsers_Empty_Ids()
        {
            var users = await this.ticketViewerService.GetUsers(new List<long>());

            Assert.Null(users);
        }

        [Fact]
        public async Task TestUsers_Valid_Ids()
        {

            var firstTicketsPage = await this.ticketViewerService.GetTicketsPage(string.Empty, 25);
            if (firstTicketsPage.Tickets.Count > 0)
            {
                var firstTicket = firstTicketsPage.Tickets.FirstOrDefault();
                var ticketUsers = await this.ticketViewerService.GetUsers(firstTicket.TicketUserIds);

                Assert.True(ticketUsers.Count > 0);
            }
        }
    }
}
