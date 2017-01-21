using System;
using System.Net.Http;

namespace WeatherMicroservice.Service
{
    using System.Threading.Tasks;
    using WeatherMicroservice;

    public class WundergroundWeatherService : WeatherService
    {
        private HttpClient client;
        private static readonly string WundergroundApiKey = AppConfig.Configuration["wundergroundApiKey"];
        private static readonly string WundergroundServiceString = $"http://api.wunderground.com/api/{WundergroundApiKey}/geolookup/q/";

        public WundergroundWeatherService()
        {
            this.client = new HttpClient();
        }


        public async Task<WeatherReport[]> GetWeather(double lng, double lat, int numberOfDays)
        {

            var response = await client.GetAsync(WundergroundServiceString + $"{lat.ToString()},{lng.ToString()}.json");
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Got the following forecast: " + responseString);
            return new WeatherReport[]{};
        }
    }

}