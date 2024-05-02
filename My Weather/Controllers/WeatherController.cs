using Microsoft.AspNetCore.Mvc;
using My_Weather.Models;
using My_Weather.Services;
using System;
using System.Threading.Tasks;

namespace My_Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<WeatherForecast>> GetWeather(string city)
        {
            try
            {
                var weatherForecast = await _weatherService.GetWeatherForecast(city);
                return Ok(weatherForecast);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("current")]
        public async Task<ActionResult<WeatherForecast>> GetCurrentWeather(string city)
        {
            try
            {
                var weatherForecast = await _weatherService.GetWeatherForecast(city);
                return Ok(weatherForecast);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
