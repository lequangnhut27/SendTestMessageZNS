using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendTestMessageZNS.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendTestMessageZNS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZnsController : ControllerBase
    {
        private readonly IZnsService _znsService;
        public ZnsController(IZnsService znsService)
        {
            _znsService = znsService;
        }

        [HttpGet("template/all")]
        public async Task<string> GetAllTemplates(string data)
        {
            data = "{\"offset\":0,\"limit\":100}";  // dữ liệu mẫu
            var response = await _znsService.GetAllTemplates(data);
            return response;
        }

        [HttpGet("template/info")]
        public async Task<string> GetTemplateInfo(int templateId)
        {
            var response = await _znsService.GetTemplateInfo(templateId);
            return response;
        }

        [HttpGet("template/sample-data")]
        public async Task<string> GetTemplateSampleData(int templateId)
        {
            var response = await _znsService.GetTemplateInfo(templateId);
            return response;
        }

        [HttpPost("message/template")]
        public async Task<string> SendMessage(string data = "")
        {
            var response = await _znsService.SendMessage(data);
            return response;
        }

        [HttpGet("message/status")]
        public async Task<string> GetMessageStatus(string data = "")
        {
            var response = await _znsService.GetMessageStatus(data);
            return response;
        }

    }
}
