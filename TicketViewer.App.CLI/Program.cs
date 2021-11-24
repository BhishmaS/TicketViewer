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
            var username = Configuration["Username"];
            var password = Configuration["Password"];

            AuthExtensions.BuildZendeskBasicAuthHeaders(username, password);
        }

        private static void InitializeAutoMapper()
        {
            MapperFactory.InitializeMapper("TicketViewer.Services");
        }
    }
}
