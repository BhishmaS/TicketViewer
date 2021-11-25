using System.Collections.Generic;
using System.Threading.Tasks;
using TicketViewer.Model;

namespace TicketViewer.Services
{
    public interface ITicketViewerService
    {
        Task<TicketsPage> GetTicketsPage(string pageUrl = "", int pageSize = 25);

        Task<Ticket> GetTicketDetails(int ticketId);

        Task<List<User>> GetUsers(List<long> userIds);
    }
}
