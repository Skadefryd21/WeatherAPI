namespace WeatherAPI.Models
{
    public class SearchWeatherVM
    {
        public SearchModel SearchModel { get; set; } = new SearchModel();
        public WeatherModel WeatherModel { get; set; } = new WeatherModel();
    }
}
