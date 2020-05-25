using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SimpleAPI.Services;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ICarService _carService;
        public WeatherForecastController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var car = await _carService.GetAll();
            return Ok(car);
        }
    }
}
