using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace AngularNet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForecastBLL WeatherForecastBLL { get; set; }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastBLL weatherForecastBLL)
        {
            _logger = logger;
            WeatherForecastBLL = weatherForecastBLL ?? throw new Exception("WeatherForecastController - IWeatherForecastBLL is NULL.");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(WeatherForecastBLL.GetWeatherForecasts());
        }
    }
}