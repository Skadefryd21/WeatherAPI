using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class GeocodingModel
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}
