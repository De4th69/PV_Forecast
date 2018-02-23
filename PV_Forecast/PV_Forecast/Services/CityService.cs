using Newtonsoft.Json;
using PV_Forecast.Classes;
using PV_Forecast.Views.Home;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PV_Forecast.Services
{
    public class CityService
    {
        private List<City> _cityList;

        private List<Country> _countryList;
        
        public async Task<List<City>> GetCityList(string countryCode)
        {
            if (_cityList != null) return _cityList.FindAll(c => c.country.Equals(countryCode));
            await Task.Run(() =>
            {
                var assembly = typeof(HomeView).Assembly;
                var fileStream = assembly.GetManifestResourceStream("PV_Forecast.Resource.Citylist.json");
                using (var streamReader = new StreamReader(fileStream))
                {
                    var fileContent = streamReader.ReadToEnd();
                    _cityList = JsonConvert.DeserializeObject<List<City>>(fileContent);
                }
            });
            return _cityList.FindAll(c => c.country.Equals(countryCode));
        }

        public async Task<List<Country>> GetCountryList()
        {
            if (_countryList != null) return _countryList;
            await Task.Run(() =>
            {
                var assembly = typeof(HomeView).Assembly;
                var fileStream = assembly.GetManifestResourceStream("PV_Forecast.Resources.CountryList.json");
                using (var streamReader = new StreamReader(fileStream))
                {
                    var fileContent = streamReader.ReadToEnd();
                    _countryList = JsonConvert.DeserializeObject<List<Country>>(fileContent);
                }
            });
            return _countryList;
        }
    }
}
