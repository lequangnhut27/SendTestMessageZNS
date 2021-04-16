using Microsoft.AspNetCore.Http;
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
    public class OAController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOAService _OAService;

        public OAController(IConfiguration configuration,IOAService OAService)
        {
            _configuration = configuration;
            _OAService = OAService;
        }

        [HttpGet("getfollowers")]
        public async Task<string> GetAllFollowers()
        {
            string url = "https://openapi.zalo.me/v2.0/oa/getfollowers";
            string accessToken = _configuration.GetValue<string>("AccessToken");
            
            string data = "{\"offset\":0,\"count\":5}";
            var response = await _OAService.GetAllFollowers(url, accessToken, data);
            return response;
        }
    }
}
