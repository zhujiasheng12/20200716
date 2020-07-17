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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _iUserService = null;
        private readonly IConfiguration _iConfiguration;

        public UserController(ILogger<UserController> logger, IUserService userService, IConfiguration iConfiguration)
        {
            _logger = logger;
            _iUserService = userService;
            _iConfiguration = iConfiguration;

        }
        [HttpGet]
        [Route("All")]
        public IEnumerable<User> Get()
        {
            Console.WriteLine($"This is UserController {this._iConfiguration["port"]} invoke");
            var a= this._iUserService.UserAll();
            return a;
        }
        [HttpGet]
        [Route("Get")]
        public User Get(int id)
        {
            return this._iUserService.FindUser(id);
        }

        [HttpGet]
        [Route("Str")]
        public string GetStr()
        {
            return "values";
        }
    }
}
