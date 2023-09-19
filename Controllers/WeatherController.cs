using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Models;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace WeatherAPI.Controllers
{
    public class WeatherController : Controller
    {

        SearchWeatherVM temp = new SearchWeatherVM();

        string img;

        private readonly HttpClient _httpClient;

        string api = "61f40f4bee18a859511f01d87cbbc524";


        public WeatherController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(SearchModel searchInput) //TODO: NULL reference, nothing passed through searchInput
        {

            HttpResponseMessage geolocate = _httpClient.GetAsync(
                @"http://api.openweathermap.org/geo/1.0/direct?q=" + searchInput.CityName + "," + searchInput.StateCode + "," + searchInput.CountryCode + "&limit=1&appid=" + api).Result;

            string geoJson = await geolocate.Content.ReadAsStringAsync();
            geoJson.ToLower();

            string[] splitGeo = geoJson.Split(",", StringSplitOptions.TrimEntries);

            foreach (string s in splitGeo)
            {
                if (s.Contains("lat"))
                {
                    temp.WeatherModel.Lat = s.Remove(0, 6);
                }

                if (s.Contains("lon"))
                {
                    temp.WeatherModel.Lon = s.Remove(0, 6);
                }
            }

            HttpResponseMessage response = _httpClient.GetAsync(
                @"https://api.openweathermap.org/data/2.5/weather?lat=" + temp.WeatherModel.Lat + "&lon=" + temp.WeatherModel.Lon + "&appid=" + api).Result;

            string json = await response.Content.ReadAsStringAsync();
            json.ToLower();

            string[] splitArray = json.Split(",", StringSplitOptions.TrimEntries);


            //TODO: Remove unnecessary string using Remove();
            foreach (string s in splitArray)
            {
                if (s.Contains("description"))
                {
                    temp.WeatherModel.Weather = s;  
                }

                if (s.Contains("humidity"))
                {
                    temp.WeatherModel.Humidity = s;
                }

                if (s.Contains("name"))
                {
                    temp.WeatherModel.City = s;
                }

                if (s.Contains("country"))
                {
                    temp.WeatherModel.Country = s;
                }

                if (s.Contains("icon"))
                {
                    s.Remove(0, 5);
                    img = $"{s}@2x.png.crdownload";
                }
            }



            ViewData["ImgSrc"] = img;

            return View("./Views/Home/Index.cshtml", temp);
        }
        public IActionResult Index()
        {

            return View("./Views/Home/Index.cshtml");
        }
    }
}
