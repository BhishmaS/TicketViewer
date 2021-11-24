using System.Threading.Tasks;
using TicketViewer.Model;

namespace TicketViewer.Services
{
    public interface ITicketViewerService
    {
        Task<TicketsPage> GetTicketsPage(string pageUrl = "");

        Task<Ticket> GetTicketDetails(int ticketId);
    }
}
