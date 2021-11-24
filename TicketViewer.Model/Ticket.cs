using System;
using System.Collections.Generic;

namespace TicketViewer.Model
{
    public class Ticket
    {
        public long Id { get; set; }

        public long RequesterId { get; set; }

        public long AssigneeId { get; set; }
        
        public string Subject { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
