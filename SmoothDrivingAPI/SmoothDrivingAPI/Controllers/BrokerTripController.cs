using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BrokerTripController: ControllerBase
    {
        private readonly ILogger<BrokerTripController> _logger;
        private readonly IBrokerTripRepository _brokerMongoRepository;      
        public BrokerTripController(
          ILogger<BrokerTripController> logger, 
          IBrokerTripRepository brokerMongoRepository)
        {
            _brokerMongoRepository = brokerMongoRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{EntityId}")]
        public IActionResult Get([FromRoute] string EntityId)
        {
            List<BrokerTrip> brokerTrips = _brokerMongoRepository.GetBrokerTrips(EntityId);
            return Ok(brokerTrips);
        }
    }
}
