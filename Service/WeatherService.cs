namespace WeatherMicroservice.Service
{
    using System.Threading.Tasks;
    using WeatherMicroservice;

    interface WeatherService
    {
        /// Gets the weather for all of the following numberOfDays days.
        Task<WeatherReport[]> GetWeather(double lng, double lat, int numberOfDays = 5);
    }
}
