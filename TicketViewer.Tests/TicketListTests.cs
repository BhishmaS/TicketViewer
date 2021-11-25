using System;
using System.Threading.Tasks;
using TicketViewer.Services;
using Xunit;

namespace TicketViewer.Tests
{
    public class TicketListTests : BaseTest
    {
        private readonly TicketViewerService ticketViewerService;

        public TicketListTests()
        {
            this.ticketViewerService = new TicketViewerService();
        }

        [Fact]
        public async Task TestListPageSize_0()
        {
            Func<Task> ticketsListFunc = () => this.ticketViewerService.GetTicketsPage(string.Empty, 0);

            var exception = await Assert.ThrowsAsync<Exception>(ticketsListFunc);
            Assert.Equal("Error occurred while fetching tickets", exception.Message);
        }

        [Fact]
        public async Task TestListPageSize_25()
        {
            var ticketsPage = await this.ticketViewerService.GetTicketsPage(string.Empty, 25);

            Assert.True(ticketsPage.Tickets.Count <= 25);
        }
        
        [Fact]
        public async Task TestListPageSizeMoreThan_100()
        {
            var ticketsPage = await this.ticketViewerService.GetTicketsPage(string.Empty, 110);

            Assert.True(ticketsPage.Tickets.Count <= 100);
        }

        [Fact]
        public async Task TestListPageSize_Negative()
        {
            Func<Task> ticketsListFunc = () => this.ticketViewerService.GetTicketsPage(string.Empty, 0);

            var exception = await Assert.ThrowsAsync<Exception>(ticketsListFunc);
            Assert.Equal("Error occurred while fetching tickets", exception.Message);
        }
    }
}
