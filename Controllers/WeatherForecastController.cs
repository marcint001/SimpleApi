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
        private IUserService _userService;
        private ICarService _carService;


        public WeatherForecastController(IUserService userService , ICarService carService )
        {
            _userService = userService;
            _carService = carService;
           
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            var cars = await _carService.GetAll();
            return Ok(cars);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var car = await _carService.GetAll();
           return Ok(car);
        }

    }
}
