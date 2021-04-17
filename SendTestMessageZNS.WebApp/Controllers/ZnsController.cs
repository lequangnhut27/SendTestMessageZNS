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
        public async Task<IActionResult> GetAllTemplates(string data)
        {
            data = "{\"offset\":0,\"limit\":100}";  // dữ liệu mẫu
            var response = await _znsService.GetAllTemplates(data);
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        [HttpGet("template/info")]
        public async Task<IActionResult> GetTemplateInfo(int templateId)
        {
            var response = await _znsService.GetTemplateInfo(templateId);
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        [HttpGet("template/sample-data")]
        public async Task<IActionResult> GetTemplateSampleData(int templateId)
        {
            var response = await _znsService.GetTemplateInfo(templateId);
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        [HttpPost("message/template")]
        public async Task<IActionResult> SendMessage(string data = "")
        {
            var response = await _znsService.SendMessage(data);
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        [HttpGet("message/status")]
        public async Task<IActionResult> GetMessageStatus(string data = "")
        {
            var response = await _znsService.GetMessageStatus(data);
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}