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
using System.ComponentModel;
using static System.Net.WebRequestMethods;
using static WeatherAPI.Models.WeatherForecastModel;

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
            var response = await _httpClient.GetFromJsonAsync<WeatherModelVM>($"https://api.openweathermap.org/data/3.0/onecall?lat={responseGeo[0].Lat}&lon={responseGeo[0].Lon}&exclude=hourly,minutely,alerts&appid={_apiKey}");


            //Prep current and forecast properties for index
            //if (responseCurrent != null)
            //    {
            //        responseCurrent.Temp = Convert.ToDouble((responseCurrent.Temp - 272.15).ToString().Remove(4));

            //        //img = $"https://openweathermap.org/img/wn/{responseCurrent.WeatherArray[0].Icon}.png";
            //    }

            //if (responseForecast != null)
            //{
            //    foreach (Date date in responseForecast.Dates)
            //    {
            //        //img = $"https://openweathermap.org/img/wn/{date.WeatherArray[0].Icon}.png";


            //        date._Temp.Min = Convert.ToDouble((date._Temp.Min - 272.15).ToString().Remove(4));

            //        date._Temp.Max = Convert.ToDouble((date._Temp.Max - 272.15).ToString().Remove(4));
            //    }
            //}

            searchWeatherVM.WeatherModelVM.CurrentWeather = response.CurrentWeather;

            searchWeatherVM.WeatherModelVM.WeatherForecast = response.WeatherForecast;

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
