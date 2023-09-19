using System.ComponentModel;

namespace WeatherAPI.Models
{
    public class WeatherModel
    {
        public string? Lon { get; set; }
        public string? Lat { get; set; }

        [DisplayName("Current weather")]
        public string? Weather { get; set; }
        public string Humidity { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
