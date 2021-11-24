namespace TicketViewer.Common
{
    public static class DomainResolver
    {
        public static string ZendeskSubdomainName { get; set; }

        public static void ResolveZendeskDomain(string zendeskSubdomainName)
        {
            ZendeskSubdomainName = zendeskSubdomainName;
        }
    }
}
