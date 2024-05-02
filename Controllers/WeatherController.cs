using Microsoft.AspNetCore.Mvc;
using SharedModels;
using WeatherServiceContracts;
using WeatherServices;

namespace WeatherAppDI.Controllers {
    public class WeatherController : Controller {
        private readonly IWeatherService _weatherService;
        private readonly List<CityWeather> _cityWeatherList;

        public WeatherController(IWeatherService weatherService) {
            _weatherService = weatherService;
            _cityWeatherList = new List<CityWeather>() {
                new CityWeather() {
                    CityUniqueCode = "LDN",
                    CityName = "London",
                    DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
                    TemperatureFahrenheit = 33
                },

                new CityWeather() {
                    CityUniqueCode = "NYC",
                    CityName = "London",
                    DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),
                    TemperatureFahrenheit = 60
                },

                new CityWeather() {
                    CityUniqueCode = "PAR",
                    CityName = "Paris",
                    DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
                    TemperatureFahrenheit = 82
                }
            };
        }
        [Route("/")]
        public IActionResult Index() {
            return View(_weatherService.GetWeatherDetails());
        }

        [Route("/weather/{cityCode}")]
        public IActionResult WeatherDetails(string cityCode) {
            return View(_weatherService.GetWeatherByCityCode(cityCode));
        }
    }
}
