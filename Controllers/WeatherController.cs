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
using static WeatherAPI.Models.RootObject;

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
            var response = await _httpClient.GetFromJsonAsync<RootObject>($"https://api.openweathermap.org/data/3.0/onecall?lat={responseGeo[0].Lat}&lon={responseGeo[0].Lon}&exclude=hourly,minutely,alerts&appid={_apiKey}");

            if (response.Current.temp != null)
            {
                response.Current.temp = response.Current.temp - 272.15F;

                if (response.Current.temp.ToString().Length > 3)
                response.Current.temp = float.Parse(response.Current.temp.ToString().Remove(4));
            }

            for (int i = 0; i < response.WeatherForecast.Count; i++)
            {
                if (response.WeatherForecast[i].temp.day != null)
                {
                    response.WeatherForecast[i].temp.day = response.WeatherForecast[i].temp.day - 272.15F;
                    response.WeatherForecast[i].temp.max = response.WeatherForecast[i].temp.max - 272.15F;
                    response.WeatherForecast[i].temp.min = response.WeatherForecast[i].temp.min - 272.15F;

                    if (response.WeatherForecast[i].temp.day.ToString().Length > 3)
                        response.WeatherForecast[i].temp.day = float.Parse(response.WeatherForecast[i].temp.day.ToString().Remove(4));

                    if (response.WeatherForecast[i].temp.max.ToString().Length > 3)
                        response.WeatherForecast[i].temp.max = float.Parse(response.WeatherForecast[i].temp.max.ToString().Remove(4));

                    if (response.WeatherForecast[i].temp.min.ToString().Length > 3)
                        response.WeatherForecast[i].temp.min = float.Parse(response.WeatherForecast[i].temp.min.ToString().Remove(4));
                }
            }

            searchWeatherVM.WeatherModel = response;

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
