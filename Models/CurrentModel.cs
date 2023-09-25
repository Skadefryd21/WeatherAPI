using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class CurrentModel
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
}
