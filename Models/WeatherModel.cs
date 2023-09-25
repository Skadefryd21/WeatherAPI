using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherModel
    {
        public Current Current { get; set; }

        public WeatherForecast Forecast { get; set; }
    }
    public class Current
    {
        [JsonPropertyName("temp")]
        [DisplayName("Temperature")]
        public double Temp { get; set; }

        [JsonPropertyName("humidity")]
        [DisplayName("Humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("clouds")]
        [DisplayName("Clouds")]
        public double Clouds { get; set; }

        [JsonPropertyName("wind_speed")]
        [DisplayName("Wind speed")]
        public double Wind_Speed { get; set; }

        [JsonPropertyName("weather")]
        [DisplayName("Weather description")]
        public Weather[]? WeatherArray { get; set; }

    }

    public class WeatherForecast
    {
        public List<Date>? Dates { get; set; }
    }

    public class Date
    {
        [JsonPropertyName("summary")]
        [DisplayName("Summary")]
        public string Summary { get; set; }

        public Temp _Temp { get; set; }

        [JsonPropertyName("humidity")]
        [DisplayName("Humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("wind_speed")]
        [DisplayName("Wind speed")]
        public double Wind_Speed { get; set; }

        [JsonPropertyName("clouds")]
        [DisplayName("Clouds")]
        public double Clouds { get; set; }

        [JsonPropertyName("weather")]
        [DisplayName("Weather description")]
        public Weather[]? WeatherArray { get; set; }
    }

    public class Weather
    {

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public class Temp
    {
        public double Min { get; set; }

        public double Max { get; set; }
    }
}
