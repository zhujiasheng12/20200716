using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;

namespace ServiceInstance.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IConfiguration _iConfiguration;

        public HealthController(  IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;

        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            Console.WriteLine($"This is HealthController {this._iConfiguration["port"]} invoke");
            return Ok();
        }
    }
}
