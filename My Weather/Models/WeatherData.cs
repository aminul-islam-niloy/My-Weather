namespace My_Weather.Models
{
    public class WeatherData
    {
        public Coord Coord { get; set; }
        public Weather[] Weather { get; set; }
        public Main Main { get; set; }
        public string Name { get; set; }
        public Sys Sys { get; set; }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
    }

    public class Sys
    {
        public long Sunrise { get; set; }
    }

    public class WeatherSettings
    {
        public string ApiKey { get; set; }
        public string DefaultCity { get; set; }
    }
}
