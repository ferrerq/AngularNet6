using DTO;

namespace DTO
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public Temperature? Temperatures { get; set; }
        public string? Summary { get; set; }
    }
}