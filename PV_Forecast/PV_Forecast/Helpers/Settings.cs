using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PV_Forecast.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        private const string FirstRunKey = "firstRun_key";
        private static readonly bool FirstRunDefault = true;

        private const string CountryKey = "country_key";
        private static readonly string CountryDefault = "DE";

        private const string CityIdKey = "cityId_key";
        private static readonly string CityIdDefault = "";

        public static bool FirstRun
        {
            get { return AppSettings.GetValueOrDefault(FirstRunKey, FirstRunDefault); }
            set { AppSettings.AddOrUpdateValue(FirstRunKey, value); }
        }

        public static string Country
        {
            get { return AppSettings.GetValueOrDefault(CountryKey, CountryDefault); }
            set { AppSettings.AddOrUpdateValue(CountryKey, value); }
        }

        public static string CityId
        {
            get { return AppSettings.GetValueOrDefault(CityIdKey, CityIdDefault); }
            set { AppSettings.AddOrUpdateValue(CityIdKey, value); }
        }
    }
}
