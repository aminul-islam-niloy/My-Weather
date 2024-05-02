using Microsoft.Extensions.Options;
using My_Weather.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace My_Weather.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherSettings _settings;

        public WeatherService(HttpClient httpClient, IOptions<WeatherSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<WeatherForecast> GetWeatherForecast(string city = null)
        {
            if (string.IsNullOrEmpty(city))
                city = _settings.DefaultCity;

            try
            {
                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_settings.ApiKey}&units=metric";

                //var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=b3b83126babd19c8b0d8ba107d720355&units=metric";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to fetch weather data.");
                }

                var json = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

                return MapToWeatherForecast(weatherData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching weather data: {ex.Message}");
            }
        }

        private WeatherForecast MapToWeatherForecast(WeatherData weatherData)
        {
            return new WeatherForecast
            {
                CityName = weatherData.Name,
                Latitude = weatherData.Coord.Lat,
                Longitude = weatherData.Coord.Lon,
                Date = DateTime.Now,
                TemperatureC = (int)weatherData.Main.Temp,
                Summary = weatherData.Weather[0].Description,
                AirCondition = weatherData.Weather[0].Main,
                Sunrise = DateTimeOffset.FromUnixTimeSeconds(weatherData.Sys.Sunrise).DateTime,
                FeelsLikeC = (int)weatherData.Main.FeelsLike
            };
        }
    }
    }
