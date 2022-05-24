using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmoothDrivingAPI.Domain.Interfaces;
using SmoothDrivingAPI.Models;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MLController: ControllerBase
    {
        [AllowAnonymous]
        [Route("Relatorio")]
        [HttpPost]
        public async Task<IActionResult> RequestRelatorio([FromBody] RelatorioBodyRequest request)
        {
            request.entity_id = "sth_/_" + request.entity_id;
            Console.WriteLine(" ---------------- RequestRelatorio: " + request.entity_id + ", " + request.trip_id);

            using (var client = new HttpClient()){
                client.BaseAddress = new Uri("https://smoothdrivingmlservice.herokuapp.com");

                var newPostJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PostAsync("/", content)){
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();

                    return Ok(responseContent);
                }
            }
        }
    }
}
