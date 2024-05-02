using System;

namespace My_Weather.Models
{
    public class WeatherForecast
    {
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }
        public string AirCondition { get; set; }
        public DateTime Sunrise { get; set; }
        public int FeelsLikeC { get; set; }
        public int FeelsLikeF => 32 + (int)(FeelsLikeC / 0.5556);
    }
}
