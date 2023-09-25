using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class SysModel
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
