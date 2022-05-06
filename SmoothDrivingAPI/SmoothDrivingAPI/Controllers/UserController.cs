using System;
using System.Collections.Generic;
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

        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger, 
            IUserRepository userRepository, 
            IUserService userService)
        {
            _userService = userService;
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

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get([FromRoute] string Id)
        {
            var User = _userRepository.Select(Id);
            return Ok(User);
        }
        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] User user)
        {
            Tuple<List<string>, bool> Validate = _userService.ValidateDocument(user);

            if(Validate.Item2 == true){
                user.Password = _userService.CreateHashPassword(user.Password);
                
                _userRepository.Insert(user);
                return Ok(user);
            }

            return BadRequest("Error in body: " + string.Join(", ", Validate.Item1));
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult Update([FromBody] User user, [FromRoute] string Id)
        {
            if(_userService.IsValidPassword(user.Password, user.Password)){
                _userRepository.Update(user, Id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("AddVehicle/{UserId}/{CarId}")]
        public void AddVehicle([FromRoute] string UserId, [FromRoute] string CarId)
        {
            User user = _userRepository.Select(UserId);

            user.Vehicles.Add(CarId);

            _userRepository.Update(user, UserId);
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete([FromRoute] string Id)
        {
            _userRepository.Delete(Id);
        }
    }
}
