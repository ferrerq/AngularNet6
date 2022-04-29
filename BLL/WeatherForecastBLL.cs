using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WeatherForecastBLL : IWeatherForecastBLL
    {
        private IWeatherForecastDAL WeatherForecastDAL { get; set; }
        public WeatherForecastBLL(IWeatherForecastDAL weatherForecastDAL)
        {
            WeatherForecastDAL = weatherForecastDAL ?? throw new Exception("WeatherForecastBLL - IWeatherForecastDAL was NULL.");
          
        }
        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return WeatherForecastDAL.GetWeatherForecasts();
        }
    }
}
