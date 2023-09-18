using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Models;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace WeatherAPI.Controllers
{
    public class WeatherController : Controller
    {


        private readonly HttpClient _httpClient;

        public WeatherController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(WeatherModel input)
        {

            HttpResponseMessage response = _httpClient.GetAsync(@"https://api.openweathermap.org/data/2.5/weather?lat=" + input.Lat + "&lon=" + input.Lon + "&appid=cde7e8e92f266f62433a2bf35ee88590").Result;

            WeatherModel temp = new WeatherModel();

            string json = await response.Content.ReadAsStringAsync();

            json.Split(",");//Where to split?

            //TODO: After split, figure out how to assign values to correct properties in "temp"

            return View(temp);
        }
            public IActionResult Index()
        {
            return View("./Views/Home/Index.cshtml");
        }
    }
}
