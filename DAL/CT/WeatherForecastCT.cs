using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CT
{
    internal class WeatherForecastCT
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureCFelt { get; set; }
        public string? Summary { get; set; }
    }

    internal static class WeatherForecastCTExtension
    {
        public static WeatherForecastCT ToComplexType(this WeatherForecast dto)
        {
            return new WeatherForecastCT()
            {
                Date = dto.Date,
                Summary = dto.Summary,
                TemperatureC = dto.Temperatures.TemperatureC,
                TemperatureCFelt = dto.Temperatures.TemperatureCFelt
            };
        }
        public static List<WeatherForecastCT> ToComplexType(this IEnumerable<WeatherForecast> dtos)
        {
            List<WeatherForecastCT> cts = new List<WeatherForecastCT>();
            foreach (WeatherForecast dto in dtos)
            {

                cts.Add(dto.ToComplexType());

            }
            return cts;
        }
        public static WeatherForecast ToDTO(this WeatherForecastCT ct)
        {
            return new WeatherForecast()
            {
                Date = ct.Date,
                Summary = ct.Summary,
                Temperatures = new Temperature()
                {
                    TemperatureC = ct.TemperatureC,
                    TemperatureCFelt = ct.TemperatureCFelt
                }

            };
        }
        public static List<WeatherForecast> ToDTO(this IEnumerable<WeatherForecastCT> cts)
        {
            List<WeatherForecast> dtos = new List<WeatherForecast>();
            foreach (WeatherForecastCT ct in cts)
            {
                dtos.Add(ct.ToDTO());
            }
            return dtos;
        }
    }

}
