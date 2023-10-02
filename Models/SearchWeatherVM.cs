namespace WeatherAPI.Models
{
    public class SearchWeatherVM
    {
        public SearchModel SearchModel { get; set; } = new SearchModel();

        public RootObject WeatherModel { get; set; } = new RootObject();
    }
}
