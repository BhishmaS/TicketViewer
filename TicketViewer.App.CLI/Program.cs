using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using TicketViewer.Common;

namespace TicketViewer.App.CLI
{
    public class Program
    {
        private static IConfiguration Configuration;

        static async Task Main(string[] args)
        {
            InitializeConfiguration(args);
            ResolveDomains();
            InitializeZendeskAuth();
            InitializeAutoMapper();

            // Creating and running console app in a new calss
            await new Application().Run();
        }

        private static void InitializeConfiguration(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();
        }
        
        private static void ResolveDomains()
        {
            DomainResolver.ResolveZendeskDomain(Configuration["ZendeskSubdomainName"]);
        }

        private static void InitializeZendeskAuth()
        {
            if (Configuration["ZendeskAuthType"] == "TokenBased")
            {
                var token = Configuration["ZendeskAccessToken"];
                AuthExtensions.BuildZendeskAuthHeaders(
                    AuthenticationType.TokenBased,
                    token,
                    string.Empty,
                    string.Empty);
            }
            else
            {
                var email = Configuration["ZendeskEmail"];
                var password = Configuration["ZendeskPassword"];
                AuthExtensions.BuildZendeskAuthHeaders(
                    AuthenticationType.Basic,
                    string.Empty,
                    email,
                    password);
            }
        }

        private static void InitializeAutoMapper()
        {
            MapperFactory.InitializeMapper("TicketViewer.Services");
        }
    }
}
