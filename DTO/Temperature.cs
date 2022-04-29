namespace DTO
{
    public class Temperature
    {

        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public int TemperatureCFelt { get; set; }
        public int TemperatureFFelt => 32 + (int)(TemperatureC / 0.5556);
    }
}