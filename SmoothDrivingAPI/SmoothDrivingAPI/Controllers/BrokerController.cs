using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BrokerController: ControllerBase
    {     
        public BrokerController()
        {
        }

        [AllowAnonymous]
        [Route("Entities")]
        [HttpGet]
        public async Task<IActionResult> CallAPI(){
            using (var client = new HttpClient()){
                client.BaseAddress = new Uri("http://15.228.222.191:1026/v2/");
                
                client.DefaultRequestHeaders.Add("fiware-service", "helixiot");
                client.DefaultRequestHeaders.Add("fiware-servicepath", "/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                using (HttpResponseMessage response = await client.GetAsync("entities")){
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();

                    return Ok(responseContent);
                }

            }
        }
    }
}
