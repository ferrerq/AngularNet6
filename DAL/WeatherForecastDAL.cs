using DAL.CT;
using DAL.Interfaces;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WeatherForecastDAL : BaseDAL, IWeatherForecastDAL
    {

        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        public WeatherForecastDAL(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {

            return GetData().ToDTO();


        }

        private IEnumerable<WeatherForecastCT> GetData()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastCT
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                TemperatureCFelt = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
