using System.ComponentModel;

namespace WeatherAPI.Models
{
    public class SearchModel
    {
        [DisplayName("City name")]
        public string CityName { get; set; }

        [DisplayName("State code (not required if not within the US)")]
        public string? StateCode { get; set; }

        [DisplayName("Country code : example \"DK\"")]
        public string CountryCode { get; set; }
    }
}
