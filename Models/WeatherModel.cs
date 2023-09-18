using System.ComponentModel;

namespace WeatherAPI.Models
{
    public class WeatherModel
    {
        public string? Lon { get; set; }
        public string? Lat { get; set; }

        public string? Lonlat
        {
            get
            {
                string lonlat = @"Longitude: " + Lon + " Latitude: " + Lat;
                return lonlat;
            }
        }
        [DisplayName("Current weather")]
        public string? Weather { get; set; }
        public bool? Rain { get; set; }
        public string? Country { get; set; }
    }
}
