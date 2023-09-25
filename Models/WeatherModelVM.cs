using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherModelVM
    {
        [JsonPropertyName("current")]
        public CurrentModel CurrentWeather { get; set; }

        [JsonPropertyName("daily")]
        public WeatherForecastModel[] WeatherForecast { get; set; }
    }

}
