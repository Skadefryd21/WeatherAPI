using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherModel
    {

        [JsonPropertyName("lon")]
        public string Lon { get; set; }
        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("name")]
        public string City { get; set; }

        [JsonPropertyName("humidity")]
        public string? Humidity { get; set; }
        [JsonPropertyName("weather")]
        public List<Weathers>? WeatherList{ get; set; }
    }

    public class Weathers
    {
        [DisplayName("Current weather")]
        [JsonPropertyName("description")]
        public string? Weather { get; set; }

        [JsonPropertyName("icon")]
        public string? icon { get; set; }
    }
}
