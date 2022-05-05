using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult Get()
        {
            var users = _userRepository.Select();
            return Ok(users);
        }
        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] User user)
        {
            _userRepository.InsertOrUpdate(user);
            return Ok(user);
        }
    }
}
