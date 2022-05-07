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
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserService _userService;
        private readonly IVehicleService _vehicleService;

        public UserController(
            ILogger<UserController> logger, 
            IUserRepository userRepository,
            IVehicleRepository vehicleRepository, 
            IUserService userService,
            IVehicleService vehicleService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _logger = logger;
            _vehicleService = vehicleService;
            _vehicleRepository = vehicleRepository;
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
            Console.WriteLine("----------  User: ", user);
            Tuple<List<string>, bool> Validate = _userService.ValidateDocument(user);

            if(Validate.Item2 == true){
                user.Password = _userService.CreateHashPassword(user.Password);
                
                _userRepository.Insert(user);
                return Ok(user.Id);
            }

            return BadRequest("Error in body: " + string.Join(", ", Validate.Item1));
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult Update([FromBody] User user, [FromRoute] string Id)
        {
            Tuple<List<string>, bool> Validate = _userService.ValidateDocument(user);

            if(Validate.Item2 == true){
                if(_userService.IsValidPassword(user.Password, user.Password)){
                    _userRepository.Update(user, Id);
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("AddVehicle/{UserId}/{VehicleId}")]
        public IActionResult AddVehicle([FromRoute] string UserId, [FromRoute] string VehicleId)
        {
            User user = _userRepository.Select(UserId);

            user.Vehicles.Add(VehicleId);

            _userRepository.Update(user, UserId);
            return Ok(VehicleId);
        }

        [HttpPut]
        [Route("AddVehicle/{UserId}")]
        public IActionResult AddVehicle([FromRoute] string UserId, [FromBody] Vehicle vehicle)
        {
            Tuple<List<string>, bool> Validate = _vehicleService.ValidateDocument(vehicle);

            if(Validate.Item2 == true){
                _vehicleRepository.Insert(vehicle);

                User user = _userRepository.Select(UserId);

                user.Vehicles.Add(vehicle.Id);

                _userRepository.Update(user, UserId);

                return Ok();
            }
            return BadRequest("Error in body: " + string.Join(", ", Validate.Item1));
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            _userRepository.Delete(Id);
            return Ok(Id);
        }
    }
}
