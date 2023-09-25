using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class MainModel
    {
        [JsonPropertyName("temp")]
        public double Temp 
        {
            get
            {
                return Temp;
            }
            set { Temp = value - 272.15; }
        }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
    }
}
