using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmoothDrivingAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var templateUser = new UserViewModel()
            {
                Name = "Test user",
                Email = "testuser@mail.com"
            };
            return Ok(templateUser);
        }
    }
}
