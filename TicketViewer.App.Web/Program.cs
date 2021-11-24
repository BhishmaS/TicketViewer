using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using TicketViewer.Common;

namespace TicketViewer.App.Web
{
    public class Program
    {
        private static IConfiguration Configuration;

        public static void Main(string[] args)
        {
            InitializeConfiguration();
            ResolveDomains();
            InitializeZendeskAuth();
            InitializeAutoMapper();

            CreateHostBuilder(args).Build().Run();
        }

        private static void InitializeConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
