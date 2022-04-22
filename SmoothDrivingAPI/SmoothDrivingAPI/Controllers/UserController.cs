using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using SmoothDrivingAPI.Application.Models;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmoothDrivingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IDataRepository _dataRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IDataRepository dataRepository)
        {
            _userRepository = userRepository;
            _dataRepository = dataRepository;
            _logger = logger;
        }

        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await GetAsync());
        //}

        //async static Task<string> GetAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    HttpRequest req = new HttpRequest();

        //    //using (HttpClient client = new HttpClient())
        //    //{
        //    //    using (HttpResponseMessage response = await client.GetAsync("http://18.219.47.23:1026/v2/entities?id=urn:ngsi-ld:entity:002"))
        //    //    {
        //    //        using (HttpContent content = response.Content)
        //    //        {
        //    //            string myContent = await content.ReadAsStringAsync();
        //    //            //var obj2 = JsonConvert.DeserializeObject(myContent);
        //    //            //List<Tanque> obj = JsonConvert.DeserializeObject<List<Tanque>>(myContent);
        //    //            //return obj;
        //    //            return myContent;
        //    //        }
        //    //    }
        //    //}
        //}

        [HttpGet]
        public IActionResult Get()
        {


            var data = _dataRepository.Select();
            return Ok(data);

            var users = _userRepository.Select();
            return Ok(users);
        }
    }
}
