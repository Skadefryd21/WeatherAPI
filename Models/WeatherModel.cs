using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherModel
    {
        [JsonPropertyName("sys")]
        public SysModel Sys { get; set; }

        [JsonPropertyName("main")]
        public MainModel Main { get; set; }

        [JsonPropertyName("name")]
        public string City { get; set; }

        [JsonPropertyName("weather")]
        [DisplayName("Current weather")]
        public Weathers[]? WeatherArray{ get; set; }
    }

    public class Weathers
    {
        
        [JsonPropertyName("description")]
        [DisplayName("Current weather")]
        public string? Weather { get; set; }

        [JsonPropertyName("icon")]
        public string? icon { get; set; }
    }
}
