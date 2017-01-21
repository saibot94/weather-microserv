namespace WeatherMicroservice
{
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using WeatherMicroservice.Service;

    class WeatherController
    {
        private readonly WeatherService service;

        public WeatherController(WeatherService service) 
        {
            this.service = service;
        }

        public async Task<string> GetWeatherAsJson(double lat, double lng)
        {
            var forecast = await service.GetWeather(lat, lng);
            return JsonConvert.SerializeObject(forecast, Formatting.Indented);
        }

    }
}