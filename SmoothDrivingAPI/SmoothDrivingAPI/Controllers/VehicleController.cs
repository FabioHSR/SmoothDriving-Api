using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Enums;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
   [Route("api/v{version:apiVersion}/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(ILogger<VehicleController> logger, IVehicleRepository VehicleRepository)
        {
            _vehicleRepository = VehicleRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult Get()
        {
            var Vehicles = _vehicleRepository.Select();
            return Ok(Vehicles);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get([FromRoute] string Id)
        {
            var Vehicle = _vehicleRepository.Select(Id);
            return Ok(Vehicle);
        }

        [HttpGet]
        [Route("{Plate}")]
        public IActionResult GetByPlate([FromRoute] string Plate)
        {
            var Vehicle = _vehicleRepository.SelectByPlate(Plate);
            return Ok(Vehicle);
        }

        [HttpPost]
        [Route("Create")]
        public void Create([FromBody] Vehicle vehicle)
        {
            vehicle.Plate = vehicle.Plate.ToUpper();
            _vehicleRepository.Insert(vehicle);
        }
        
        [HttpPut]
        [Route("{Id}")]
        public void Update([FromBody] Vehicle vehicle, [FromRoute] string Id)
        {
            _vehicleRepository.Update(vehicle, Id);
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete([FromRoute] string Id)
        {
            _vehicleRepository.Delete(Id);
        }
    }
}
