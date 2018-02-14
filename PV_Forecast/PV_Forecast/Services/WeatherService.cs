using Newtonsoft.Json;
using PV_Forecast.Views.Home;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PV_Forecast.Services
{
    public class WeatherService
    {
        private string _apiKey { get; set; }

        /// <summary>
        /// Reads the api key for openweathermap.org from ApiKey.txt file. The Build Action for the file must be set to EmbeddedResource and must be placed in the Resources folder in the PCL
        /// </summary>
        private void GetApiKey()
        {
            var assembly = typeof(HomeView).Assembly;
            var fileStream = assembly.GetManifestResourceStream("PV_Forecast.Resources.ApiKey.txt");
            using(var reader = new StreamReader(fileStream))
            {
                _apiKey = reader.ReadToEnd();
            }
        }

        public static WeatherService Instance = new WeatherService();

        public WeatherService()
        {
            GetApiKey();
        }

        public void GetWeatherForToday()
        {

        }
    }
}
