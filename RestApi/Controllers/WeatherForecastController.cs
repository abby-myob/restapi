using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("/api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastStore _forecastStore; 
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastStore forecastStore)
        {
            _logger = logger;          
            _forecastStore = forecastStore;
        }

        [HttpGet("forecast/{city}")]
        public ObjectResult Get(string city)
        {
            try
            { 
                _logger.LogInformation("Fetching all the Cities from the storage"); 
                
                var getCity = _forecastStore.CityForecasts.First(f => f.CityName == city);
 
                _logger.LogInformation($"Returning {getCity.CityName}.");
 
                return Ok(getCity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            } 
        }
        
        [HttpGet("forecast")]
        public ObjectResult Get()
        {
            try
            { 
                _logger.LogInformation("Fetching all the Students from the storage");  
 
                return Ok(_forecastStore.CityForecasts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            } 
            return _forecastStore.CityForecasts;
        }

        [HttpPost("forecast")]
        public ICityForecast HandlePost([FromBody] CityForecast cityForecast)
        { 
            _forecastStore.CityForecasts.Add(cityForecast); 
            return cityForecast;
        }
        
        [HttpDelete("forecast/{city}")]
        public IEnumerable<ICityForecast> HandlePost(string city)
        {
            var cityObject = _forecastStore.CityForecasts.First(f => f.CityName == city);
            _forecastStore.CityForecasts.Remove(cityObject);
            return _forecastStore.CityForecasts;
        }
    }
}