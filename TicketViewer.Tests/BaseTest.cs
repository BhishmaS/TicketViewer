using Microsoft.Extensions.Configuration;
using System.IO;
using TicketViewer.Common;

namespace TicketViewer.Tests
{
    public class BaseTest
    {
        private readonly IConfiguration _configuration;

        public BaseTest()
        {
            this._configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            this.InitializeApplicationDefaults();
        }

        private void InitializeApplicationDefaults()
        {
            this.ResolveDomains();
            this.InitializeZendeskAuth();
            this.InitializeAutoMapper();
        }

        private void ResolveDomains()
        {
            DomainResolver.ResolveZendeskDomain(this._configuration["ZendeskSubdomainName"]);
        }

        private void InitializeZendeskAuth()
        {
            if (this._configuration["ZendeskAuthType"] == "TokenBased")
            {
                var token = this._configuration["ZendeskAccessToken"];
                AuthExtensions.BuildZendeskAuthHeaders(
                    AuthenticationType.TokenBased,
                    token,
                    string.Empty,
                    string.Empty);
            }
            else
            {
                var username = this._configuration["ZendeskUsername"];
                var password = this._configuration["ZendeskPassword"];
                AuthExtensions.BuildZendeskAuthHeaders(
                    AuthenticationType.Basic,
                    string.Empty,
                    username,
                    password);
            }
        }

        private void InitializeAutoMapper()
        {
            MapperFactory.InitializeMapper("TicketViewer.Services");
        }
    }
}
