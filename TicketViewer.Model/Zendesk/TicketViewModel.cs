using System;
using System.Collections.Generic;

namespace TicketViewer.Model.Zendesk
{
    public class TicketViewModel
    {
        public long id { get; set; }

        public long requester_id { get; set; }

        public long assignee_id { get; set; }

        public string subject { get; set; }

        public string description { get; set; }

        public string type { get; set; }

        public string priority { get; set; }

        public List<string> tags { get; set; }

        public string status { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
