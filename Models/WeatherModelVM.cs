using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class WeatherModelVM
    {
        public CurrentModel CurrentWeather { get; set; } = new CurrentModel();

        public WeatherForecastModel WeatherForecast { get; set; } = new WeatherForecastModel();
    }

}
