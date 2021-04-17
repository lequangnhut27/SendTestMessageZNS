using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SendTestMessageZNS.Service.Services
{
    public interface IZnsService
    {
        Task<HttpResponseMessage> GetAllTemplates(string data);
        Task<HttpResponseMessage> GetTemplateInfo(int templateId);
        Task<HttpResponseMessage> GetTemplateSampleData(int templateId);
        Task<HttpResponseMessage> SendMessage(string data);
        Task<HttpResponseMessage> GetMessageStatus(string data);


    }
    public class ZnsService : IZnsService
    {
        private readonly HttpClient _client;
        public ZnsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetAllTemplates(string data)
        {
            //Tạo request
            string url = "template/all";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Content = new StringContent(data);

            // Call API
            var response = await _client.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetTemplateInfo(int templateId)
        {
            //Tạo request
            string url = $"template/all?template_id={templateId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Call API
            var response = await _client.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetTemplateSampleData(int templateId)
        {
            //Tạo request
            string url = $"template/sample-data?template_id={templateId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            // Call API
            var response = await _client.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> SendMessage(string data)
        {
            //Tạo request
            string url = "message/template";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(data);

            // Call API
            var response = await _client.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetMessageStatus(string data)
        {
            //Tạo request
            string url = "message/status";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Content = new StringContent(data);

            // Call API
            var response = await _client.SendAsync(request);

            return response;
        }
    }
}
