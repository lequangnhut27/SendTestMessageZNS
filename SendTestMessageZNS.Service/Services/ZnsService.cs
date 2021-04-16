using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendTestMessageZNS.Service.Services
{
    public interface IZnsService
    {
        Task<string> SendMessage(string url, string accessToken, string data);
    }
    public class ZnsService : IZnsService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ZnsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> SendMessage(string url, string accessToken, string data)
        {
            //Tạo request
            Uri uri = new Uri(url);
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Add("access_token", accessToken);
            request.Content = new StringContent(data);

            // Call API
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();


        }
    }
}
