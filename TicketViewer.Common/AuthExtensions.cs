using System;
using System.Net.Http.Headers;
using System.Text;

namespace TicketViewer.Common
{
    public static class AuthExtensions
    {
        private static AuthenticationHeaderValue ZendeskBasicAuthHeaders { get; set; }

        public static void BuildZendeskBasicAuthHeaders(string username, string password)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            ZendeskBasicAuthHeaders = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public static AuthenticationHeaderValue GetZendeskBasicAuthHeaders()
        {
            return ZendeskBasicAuthHeaders;
        }
    }
}
