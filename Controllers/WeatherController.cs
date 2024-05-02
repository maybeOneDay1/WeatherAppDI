using Microsoft.AspNetCore.Mvc;
using SharedModels;
using WeatherServiceContracts;
using WeatherServices;

namespace WeatherAppDI.Controllers {
    public class WeatherController : Controller {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService) {
            _weatherService = weatherService;
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
