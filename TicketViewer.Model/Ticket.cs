using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketViewer.Model
{
    public class Ticket
    {
        public long Id { get; set; }
        
        public string Subject { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Priority { get; set; }

        public List<string> Tags { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long RequesterId { get; set; }

        public long AssigneeId { get; set; }

        public List<long> TicketUserIds => new() { this.RequesterId, this.AssigneeId };

        public List<User> TicketUsers { get; set; }

        public User Requester => this.TicketUsers.SingleOrDefault(u => u.Id == this.RequesterId);

        public User Assignee => this.TicketUsers.SingleOrDefault(u => u.Id == this.AssigneeId);
    }
}
