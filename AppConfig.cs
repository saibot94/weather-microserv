namespace WeatherMicroservice
{
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public static class AppConfig
    {

        private static IConfigurationRoot  appCfg;
        public static IConfigurationRoot  Configuration
        {
            get
            {
                if (appCfg == null)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("config.json");

                    appCfg = builder.Build();
                }
                return appCfg;
            }
        }
    }
}
