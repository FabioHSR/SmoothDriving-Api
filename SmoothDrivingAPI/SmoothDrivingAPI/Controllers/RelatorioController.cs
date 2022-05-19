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
    public class RelatorioController : ControllerBase
    {
        private readonly ILogger<RelatorioController> _logger;
        private readonly IRelatorioRepository _relatorioRepository;      
        public RelatorioController(ILogger<RelatorioController> logger, 
        IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult Get()
        {
            var Relatorios = _relatorioRepository.Select();
            return Ok(Relatorios);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get([FromRoute] string Id)
        {
            var Relatorio = _relatorioRepository.Select(Id);
            return Ok(Relatorio);
        }

        [HttpGet]
        [Route("BrokerTrip/{BrokerTripId}")]
        public IActionResult GetByEntityId([FromRoute] string BrokerTripId)
        {
            Console.WriteLine("BrokerTripId: " + BrokerTripId);
            Relatorio Relatorio = _relatorioRepository.SelectByTripId(BrokerTripId);
            
            if(Relatorio == null)
            {
                return NotFound();
            }
            
            return Ok(Relatorio);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Relatorio relatorio)
        {
            return Created("", relatorio);
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete([FromRoute] string Id)
        {
            _relatorioRepository.Delete(Id);
        }
    }
}
