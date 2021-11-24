using System.Collections.Generic;

namespace TicketViewer.Model.Zendesk
{
    public class TicketListViewModel
    {
        public List<TicketViewModel> tickets { get; set; }

        public string next_page { get; set; }

        public string previous_page { get; set; }

        public string count { get; set; }
    }
}
