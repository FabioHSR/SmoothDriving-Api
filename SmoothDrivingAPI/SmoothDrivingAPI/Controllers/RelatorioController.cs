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
        private readonly IRelatorioService _relatorioService;        
        public RelatorioController(ILogger<RelatorioController> logger, 
        IRelatorioRepository relatorioRepository, IRelatorioService relatorioService)
        {
            _relatorioRepository = relatorioRepository;
            _relatorioService = relatorioService;
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

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Relatorio relatorio)
        {
            return Created("", relatorio);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult Update([FromBody] Relatorio relatorio, [FromRoute] string Id)
        {
            Tuple<List<string>, bool> Validate = _relatorioService.ValidateDocument(relatorio);

            if(Validate.Item2 == true){
                relatorio.Duration = _relatorioService.calculateRelatorioDuration(
                    relatorio.DateTimeStart, relatorio.DateTimeEnd);

                _relatorioRepository.Update(relatorio, Id);
                return Ok(relatorio);
            }
            return BadRequest(string.Join(", ", Validate.Item1));
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete([FromRoute] string Id)
        {
            _relatorioRepository.Delete(Id);
        }
    }
}
