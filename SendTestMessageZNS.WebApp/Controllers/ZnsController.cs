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
        private readonly IConfiguration _configuration;
        private readonly IZnsService _znsService;
        public ZnsController(IConfiguration configuration, IZnsService znsService)
        {
            _configuration = configuration;
            _znsService = znsService;
        }
        [HttpPost("message")]
        public async Task<string> SendMessage()
        {
            string url = "https://business.openapi.zalo.me/message/template";
            string accessToken = _configuration.GetValue<string>("AccessToken");

            string data = "";
            var response = await _znsService.SendMessage(url, accessToken, data);
            return response;
        }
    }
}
