using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class RootObject
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public string timezone { get; set; }
        [JsonPropertyName("current")]
        public Current Current { get; set; }
        [JsonPropertyName("daily")]
        public List<Daily> WeatherForecast { get; set; }
    }

    public class Current
    {
        public int dt { get; set; }
        [DisplayName("Temperature")]
        public float temp { get; set; }
        [DisplayName("Humidity")]
        public int humidity { get; set; }
        [DisplayName("UV Index")]
        public float uvi { get; set; }
        [DisplayName("Clouds")]
        public int clouds { get; set; }
        [DisplayName("Wind speed")]
        public float wind_speed { get; set; }
        public Weather[] weather { get; set; }
    }

    public class Daily
    {
        public int dt { get; set; }
        public string summary { get; set; }
        public Temp temp { get; set; }
        public Feels_Like feels_like { get; set; }
        public int humidity { get; set; }
        public float wind_speed { get; set; }
        public Weather[] weather { get; set; }
        public int clouds { get; set; }
        public float rain { get; set; }
        public float uvi { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        [DisplayName("Weather description")]
        public string main { get; set; }
        public string icon { get; set; }
        public string iconURL => $"https://openweathermap.org/img/wn/{icon}@2x.png";
    }

    public class Temp
    {
        public float day { get; set; }
        public float min { get; set; }
        public float max { get; set; }
        public float night { get; set; }
        public float eve { get; set; }
        public float morn { get; set; }
    }

    public class Feels_Like
    {
        public float day { get; set; }

        public float night { get; set; }
        public float eve { get; set; }
        public float morn { get; set; }
    }
}


