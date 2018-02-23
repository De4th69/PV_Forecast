
using PV_Forecast.Resources;
using PV_Forecast.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PV_Forecast.Views.Home
{
    public class HomeView : ContentPage
    {
        public HomeView()
        {
            Title = AppResource.AppName;

            var stack = new StackLayout();
            
            Content = stack;

            WeatherService.Instance.GetWeatherForToday();
        }
    }
}
