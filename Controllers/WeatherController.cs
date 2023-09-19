using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Models;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace WeatherAPI.Controllers
{
    public class WeatherController : Controller
    {

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

            //Geolocate location
            HttpResponseMessage responseGeo = _httpClient.GetAsync(
                @"http://api.openweathermap.org/geo/1.0/direct?q=" + searchInput.CityName + "," + searchInput.StateCode + "," + searchInput.CountryCode + "&limit=1&appid=" + api).Result;

            //TDO: The response body has to be converted into a json file that will then be used as the deserialization object later on

            //Deserialize
            var jsonGeo = JsonConvert.DeserializeObject<WeatherModel>(responseGeo.Content.ReadAsStringAsync().Result);

            //Get data of location
            HttpResponseMessage response = _httpClient.GetAsync(
                @"https://api.openweathermap.org/data/2.5/weather?lat=" + jsonGeo.Lat + "&lon=" + jsonGeo.Lon + "&appid=" + api).Result;

            //Deserialize
            var json = JsonConvert.DeserializeObject<WeatherModel>(response.Content.ReadAsStringAsync().Result);

            //Set png
            ViewData["ImgSrc"] = img;

            //Return data to view
            return View("./Views/Home/Index.cshtml", json);
        }
        public IActionResult Index()
        {

            return View("./Views/Home/Index.cshtml");
        }
    }
}
