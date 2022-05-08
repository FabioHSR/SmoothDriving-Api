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
            Tuple<List<string>, bool> Validate = _userService.ValidateDocument(user);

            if(Validate.Item2 == false){
                return BadRequest(string.Join(", ", Validate.Item1));
            }
            
            user.Email = user.Email.ToLower();
            user.Password = _userService.CreateHashPassword(user.Password);
            _userRepository.Insert(user);

            return Ok(user.Id);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            Console.WriteLine("Login");

            if(!_userRepository.Exists("Email", user.Email)){
                return BadRequest("Falha na autenticação.");
            }

            User User = _userRepository.SelectByEmail(user.Email);
            
            Console.WriteLine("Validando password");
            
            if(_userService.IsValidPassword(user.Password, User.Password))
                return Ok(User);

            return BadRequest("Falha na autenticação.");
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult Update([FromBody] User user, [FromRoute] string Id)
        {
            Tuple<List<string>, bool> Validate = _userService.ValidateDocument(user);

            if(Validate.Item2 == false){
                return BadRequest(string.Join(", ", Validate.Item1));
            }

            if(!_userService.IsValidPassword(user.Password, user.Password)){
                return BadRequest("Invalid password.");
            }

            _userRepository.Update(user, Id);
            return Ok();
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
            Console.WriteLine("AddVehicle: " + vehicle);
            Tuple<List<string>, bool> Validate = _vehicleService.ValidateDocument(vehicle);

            if(Validate.Item2 == false){
                return BadRequest(string.Join(", ", Validate.Item1));
            }

            string VehicleId = vehicle.Id;
            Vehicle vehicleByPlate = _vehicleRepository.SelectByPlate(vehicle.Plate);

            // If the vehicle already exists, use the existing id 
            // instead of creating a new one by BaseEntity
            if(vehicleByPlate != null){
                VehicleId = vehicleByPlate.Id;
            }

            _vehicleRepository.Insert(vehicle);
            
            User user = new User();
            user.Id = UserId;
            user.Vehicles.Add(VehicleId);

            _userRepository.Update(user, UserId);

            return Ok();
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
