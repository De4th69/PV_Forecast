using Plugin.Connectivity;
using PV_Forecast.Helpers;
using PV_Forecast.Views.Home;
using PV_Forecast.Views.Initial;
using Xamarin.Forms;

namespace PV_Forecast
{
    public class App : Application
    {
        public App()
        {
            if (Settings.FirstRun)
            {
                MainPage = new InitialView();
            }
            else
            {
                MainPage = new NavigationPage(new HomeView());
            }            
        }

        protected override void OnStart()
        {
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;
        }

        protected override void OnResume()
        {
            base.OnResume();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            //TODO: If app is in startup load weather data from db.
        }
    }
}
