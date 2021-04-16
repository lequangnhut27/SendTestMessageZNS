using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendTestMessageZNS.Service.Services
{
    public interface IZnsService
    {
        Task<string> GetAllTemplates(string data);
        Task<string> GetTemplateInfo(int templateId);
        Task<string> GetTemplateSampleData(int templateId);
        Task<string> SendMessage(string data);
        Task<string> GetMessageStatus(string data);


    }
    public class ZnsService : IZnsService
    {
        private readonly HttpClient _client;
        public ZnsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetAllTemplates(string data)
        {
            //Tạo request
            string url = "template/all";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Content = new StringContent(data);

            // Call API
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTemplateInfo(int templateId)
        {
            //Tạo request
            string url = $"template/all?template_id={templateId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Call API
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTemplateSampleData(int templateId)
        {
            //Tạo request
            string url = $"template/sample-data?template_id={templateId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Call API
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SendMessage(string data)
        {
            //Tạo request
            string url = "message/template";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(data);

            // Call API
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetMessageStatus(string data)
        {
            //Tạo request
            string url = "message/status";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Content = new StringContent(data);

            // Call API
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }



    }
}
