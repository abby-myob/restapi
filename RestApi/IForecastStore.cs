using System.Collections.Generic;

namespace RestApi
{
    public interface IForecastStore
    {
        List<ICityForecast> CityForecasts { get; set; } 
    }
}