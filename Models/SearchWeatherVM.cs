namespace WeatherAPI.Models
{
    public class SearchWeatherVM
    {
        public SearchModel SearchModel { get; set; } = new SearchModel();

        public WeatherModelVM WeatherModelVM { get; set; } = new WeatherModelVM();


    }
}
