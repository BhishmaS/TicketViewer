using System.Collections.Generic;

namespace TicketViewer.Model.Zendesk
{
    public class UsersListViewModel
    {
        public UsersListViewModel()
        {
            this.users = new List<User>();
        }

        public List<User> users { get; set; }
    }
}
