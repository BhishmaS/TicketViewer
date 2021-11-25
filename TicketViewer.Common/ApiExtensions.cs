using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketViewer.Common
{
    public static class ApiExtensions
    {
        public static async Task<KeyValuePair<HttpStatusCode, string>> SendHttpRequest(
            this string restEndpoint,
            HttpMethod httpMethod,
            string payLoad = "")
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = AuthExtensions.GetZendeskAuthHeaders();

                var content = new StringContent(payLoad, Encoding.UTF8);
                var httpRequestMessage = new HttpRequestMessage(httpMethod, restEndpoint) { Content = content };
                var httpResponse = await httpClient.SendAsync(httpRequestMessage);
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(await httpResponse.Content.ReadAsStringAsync());
                }

                return new KeyValuePair<HttpStatusCode, string>(httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception("Error while sending HTTP request", ex);
            }
        }
    }
}
