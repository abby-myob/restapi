namespace RestApi
{
    public interface ICityForecast
    {
        string CityName { get; set; }
        float Temperature { get; set; }
    }

    public class CityForecast : ICityForecast
    {
        public string CityName { get; set; }
        public float Temperature { get; set; }
    }
}