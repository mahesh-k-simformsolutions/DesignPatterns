using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace TemperatureService.Controllers
{
    [Route("[controller]")]
    public class CelsiusController : ControllerBase
    {
        private static int _counter = 0;
        private static readonly Random randomTemperature = new();

        [HttpGet("{locationId}")]
        public ActionResult Get(int locationId)
        {
            _counter++;
            return _counter % 4 != 0
                ? Ok(randomTemperature.Next(0, 100))
                : (ActionResult)StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong when getting the temperature.");
        }
    }
}
