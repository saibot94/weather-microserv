using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


using Newtonsoft.Json;
using WeatherMicroservice.Service;


namespace WeatherMicroservice
{


    public class Startup
    {

        private WeatherController weatherController = new WeatherController(new WundergroundWeatherService());
        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<WeatherService, WundergroundWeatherService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var latString = context.Request.Query["lat"].FirstOrDefault();
                var longString = context.Request.Query["long"].FirstOrDefault();

                var lat = latString.TryParse();
                var lng = longString.TryParse();

                if (lat.HasValue && lng.HasValue)
                {
                    var forecast = new List<WeatherReport>();
                    for (var days = 1; days < 6; days++)
                    {
                        forecast.Add(new WeatherReport(lat.Value, lng.Value, days));
                    }
                    var json = JsonConvert.SerializeObject(forecast, Formatting.Indented);

                    await weatherController.GetWeatherAsJson(lat.Value, lng.Value);
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    await context.Response.WriteAsync("You must specify both 'lat' and 'long'");
                }
            });
        }
    }

}
