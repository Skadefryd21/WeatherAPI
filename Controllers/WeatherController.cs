using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.IO.Compression;

namespace WeatherAPI.Controllers
{
    public class WeatherController : Controller
    {
        private string img;

        SearchWeatherVM searchWeatherVM = new SearchWeatherVM();

        private readonly string _apiKey;

        private readonly HttpClient _httpClient;

        public WeatherController(string apiKey)
        {
            _apiKey = apiKey;

            _httpClient = new HttpClient(); 
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(SearchWeatherVM searchInput)
        {

            //Geolocate location
            var responseGeo = await _httpClient.GetFromJsonAsync<GeocodingModel[]>($"http://api.openweathermap.org/geo/1.0/direct?q={searchInput.SearchModel.CityName},{searchInput.SearchModel.StateCode},{searchInput.SearchModel.CountryCode}&limit=1&appid={_apiKey}");

            //Get deserialized data of location
            var response = await _httpClient.GetFromJsonAsync<WeatherModel>($"https://api.openweathermap.org/data/2.5/weather?lat={responseGeo[0].Lat}&lon={responseGeo[0].Lon}&appid={_apiKey}");
           
            if ( response != null )
            {
                searchWeatherVM.WeatherModel = response;
            }

            //Set png
            ViewData["ImgSrc"] = img;
            
            //Return data to view
            return View("./Views/Home/Index.cshtml", searchWeatherVM);
        }
        public IActionResult Index()
        {

            return View("./Views/Home/Index.cshtml");
        }
    }
}
