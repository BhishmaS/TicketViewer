using System;
using System.Collections.Generic;
using TicketViewer.Model;

namespace TicketViewer.App.Web.Models
{
    public class TicketDetailsViewModel
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

        public User Requester { get; set; }

        public User Assignee { get; set; }
    }
}
