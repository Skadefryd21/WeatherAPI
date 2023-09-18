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

            string[] splitArray = json.Split(",");//Where to split?

            
            foreach (var i in splitArray)
            {
                temp.Weather += i;
            }

            return View(temp);
            //TODO: InvalidOperationException: The view 'GetWeather' was not found. The following locations were searched:/ Views / Weather / GetWeather.cshtml/ Views / Shared / GetWeather.cshtml

            //TODO: After split, figure out how to assign values to correct properties in "temp"
        }
        public IActionResult Index()
        {
            return View("./Views/Home/Index.cshtml");
        }
    }
}
