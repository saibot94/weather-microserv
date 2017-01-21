namespace WeatherMicroservice.Service 
{
    using WeatherMicroservice;

    interface WeatherService 
    {
        /// Gets the weather for all of the following numberOfDays days.
        WeatherReport[] getWeather(int numberOfDays = 5);
    }
}
