using System.Collections.Generic;
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
        public async Task TestTicketsList()
        {
            var users = await this.ticketViewerService.GetUsers(new List<long>());

            Assert.True(users.Count > 0);
        }
    }
}
