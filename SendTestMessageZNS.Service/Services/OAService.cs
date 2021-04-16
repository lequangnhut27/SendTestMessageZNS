using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendTestMessageZNS.Service.Services
{
    public interface IOAService
    {
        Task<string> GetAllFollowers(string url, string accessToken, string data);
    }
    public class OAService : IOAService
    {
        private readonly IHttpClientFactory _clientFactory;
        public OAService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        public async Task<string> GetAllFollowers(string url, string accessToken, string data)
        {
            // Tạo request
            string uriRequest = $"{url}?access_token={accessToken}";
            Uri uri = new Uri(uriRequest);
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Content = new StringContent(data);

            // Call API
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
