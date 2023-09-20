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

        string img;

        private readonly HttpClient _httpClient;

        string api = "61f40f4bee18a859511f01d87cbbc524";


        public WeatherController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(SearchWeatherVM searchInput)
        {

            //Geolocate location
            var responseGeo = _httpClient.GetFromJsonAsync<WeatherModel[]>($"http://api.openweathermap.org/geo/1.0/direct?q={searchInput.SearchModel.CityName},{searchInput.SearchModel.StateCode},{searchInput.SearchModel.CountryCode}&limit=1&appid={api}").Result;

            //Get deserialized data of location
            var response = _httpClient.GetFromJsonAsync<WeatherModel>($"https://api.openweathermap.org/data/2.5/weather?lat={responseGeo[0].Lat}&lon={responseGeo[0].Lon}&appid={api}").Result;
            
            //Set png
            ViewData["ImgSrc"] = img;

            //Return data to view
            return View("./Views/Home/Index.cshtml", response);
        }
        public IActionResult Index()
        {

            return View("./Views/Home/Index.cshtml");
        }
    }
}
