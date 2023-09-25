using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherForecastModel
    {
        public List<Date>? Dates { get; set; }

        public class Date
        {
            [JsonPropertyName("summary")]
            [DisplayName("Summary")]
            public string Summary { get; set; }

            [JsonPropertyName("humidity")]
            [DisplayName("Humidity")]
            public double Humidity { get; set; }

            [JsonPropertyName("wind_speed")]
            [DisplayName("Wind speed")]
            public double Wind_Speed { get; set; }

            [JsonPropertyName("clouds")]
            [DisplayName("Clouds")]
            public double Clouds { get; set; }


            [JsonPropertyName("temp")]
            public Temp _Temp { get; set; }

            [JsonPropertyName("weather")]
            [DisplayName("Weather description")]
            public Weather[]? WeatherArray { get; set; }
        }

        public class Temp
        {
            [JsonPropertyName("min")]
            [DisplayName("Lowest temperature")]
            public double Min { get; set; }

            [JsonPropertyName("max")]
            [DisplayName("Highest temperature")]
            public double Max { get; set; }
        }

    }
}
