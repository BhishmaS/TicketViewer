using System;
using System.Net.Http.Headers;
using System.Text;

namespace TicketViewer.Common
{
    public static class AuthExtensions
    {
        private static AuthenticationType AuthenticationType { get; set; }

        private static AuthenticationHeaderValue ZendeskBasicAuthHeaders { get; set; }

        private static AuthenticationHeaderValue ZendeskBearerAuthHeaders { get; set; }

        public static void BuildZendeskAuthHeaders(AuthenticationType authType, string token, string email, string password)
        {
            AuthenticationType = authType;

            //// For Token Based Auth
            ZendeskBearerAuthHeaders = new AuthenticationHeaderValue("Bearer", token);

            //// For Basic Auth
            var byteArray = Encoding.ASCII.GetBytes($"{email}:{password}");
            ZendeskBasicAuthHeaders = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public static AuthenticationHeaderValue GetZendeskAuthHeaders()
        {
            if (AuthenticationType == AuthenticationType.TokenBased)
            {
                return ZendeskBearerAuthHeaders;
            }

            return ZendeskBasicAuthHeaders;
        }
    }

    public enum AuthenticationType
    {
        Basic = 0,
        TokenBased = 1,
    }
}
