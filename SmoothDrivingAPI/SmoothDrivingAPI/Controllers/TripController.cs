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
    public class TripController : ControllerBase
    {
        private readonly ILogger<TripController> _logger;
        private readonly ITripRepository _tripRepository;
        private readonly ITripService _tripService;        
        public TripController(ILogger<TripController> logger, ITripRepository TripRepository, ITripService TripService)
        {
            _tripRepository = TripRepository;
            _tripService = TripService;
            _logger = logger;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult Get()
        {
            var Trips = _tripRepository.Select();
            return Ok(Trips);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get([FromRoute] string Id)
        {
            var Trip = _tripRepository.Select(Id);
            return Ok(Trip);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Trip trip)
        {
            Tuple<List<string>, bool> Validate = _tripService.ValidateDocument(trip);

            if(Validate.Item2 == true){
                trip.Duration = _tripService.calculateTripDuration(
                    trip.DateTimeStart, trip.DateTimeEnd);

                _tripRepository.Insert(trip);

                return Created("", trip);
            } 
            return BadRequest(string.Join(", ", Validate.Item1));
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult Update([FromBody] Trip trip, [FromRoute] string Id)
        {
            Tuple<List<string>, bool> Validate = _tripService.ValidateDocument(trip);

            if(Validate.Item2 == true){
                trip.Duration = _tripService.calculateTripDuration(
                    trip.DateTimeStart, trip.DateTimeEnd);

                _tripRepository.Update(trip, Id);
                return Ok(trip);
            }
            return BadRequest(string.Join(", ", Validate.Item1));
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete([FromRoute] string Id)
        {
            _tripRepository.Delete(Id);
        }
    }
}
