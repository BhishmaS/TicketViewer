﻿namespace TicketViewer.Model.Zendesk
{
    public static class ApiUrlConstants
    {
        public const string TicketsListAPI = "https://{0}/api/v2/tickets.json?per_page=25";
        public const string TicketDetailsAPI = "https://{0}/api/v2/tickets/{1}.json";
    }
}
