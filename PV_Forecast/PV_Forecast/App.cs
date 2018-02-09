using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PV_Forecast
{
    public class App : Application
    {
        public App()
        {
            MainPage = new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello World"
                }
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
