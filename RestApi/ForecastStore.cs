using System.Collections.Generic;

namespace RestApi
{
    public class ForecastStore : IForecastStore
    {
        public List<ICityForecast> CityForecasts { get; set; }

        public ForecastStore()
        {
            CityForecasts = new List<ICityForecast>();
        }
    }
}