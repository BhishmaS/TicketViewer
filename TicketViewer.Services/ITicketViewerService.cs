using System.Collections.Generic;
using System.Threading.Tasks;
using TicketViewer.Model;

namespace TicketViewer.Services
{
    public interface ITicketViewerService
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
    }
}
