﻿using System.Threading.Tasks;
using TicketViewer.Services;
using Xunit;

namespace TicketViewer.Tests
{
    public class TicketDetailsTests : BaseTest
    {
        private readonly TicketViewerService ticketViewerService;

        public TicketDetailsTests()
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
