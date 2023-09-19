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

        WeatherModel temp = new WeatherModel();

        string img;

        private readonly HttpClient _httpClient;

        string api = "61f40f4bee18a859511f01d87cbbc524";


        public WeatherController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(SearchModel searchInput)
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
                    temp.Lat = 
                }

                if (s.Contains("lon"))
                {
                    temp.Lon = 
                }
            }

            HttpResponseMessage response = _httpClient.GetAsync(
                @"https://api.openweathermap.org/data/2.5/weather?lat=" + temp.Lat + "&lon=" + temp.Lon + "&appid=" + api).Result;

            string json = await response.Content.ReadAsStringAsync();

            json.ToLower();

            string[] splitArray = json.Split(",", StringSplitOptions.TrimEntries);





            foreach (string s in splitArray)
            {
                if (s.Contains("description"))
                {
                    temp.Weather = s;  
                }

                if (s.Contains("humidity"))
                {
                    temp.Humidity = s;
                }

                if (s.Contains("name"))
                {
                    temp.City = s;
                }

                if (s.Contains("country"))
                {
                    temp.Country = s;
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
