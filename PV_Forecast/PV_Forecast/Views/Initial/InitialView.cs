using PV_Forecast.Animations;
using PV_Forecast.Controls;
using PV_Forecast.Resources;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PV_Forecast.Views.Initial
{
    public class InitialView : ContentPage
    {
        private DefaultLabel _loadLabel;

        private DefaultLabel _loadCityLabel;

        private DefaultLabel _pickCountryLabel;

        private DefaultLabel _pickCityLabel;

        private ListView _countryListView;

        private ListView _cityListView;

        private DefaultButton _nextButton;

        private DefaultButton _previousButton;

        /// <summary>
        /// This was just to play around with the animations. It will be thrown out
        /// </summary>
        public InitialView()
        {
            Title = AppResource.AppName;            

            _loadLabel = new DefaultLabel
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = AppResource.LblLoadingText,
                Opacity = 0,
                //IsVisible = false,
            };

            _loadCityLabel = new DefaultLabel
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = AppResource.LblCityLoadingText,
                Opacity = 0,
                //IsVisible = false
            };

            _pickCountryLabel = new DefaultLabel
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = AppResource.CountryLabelText,
                Opacity = 0,
                //IsVisible = false
            };

            _pickCityLabel = new DefaultLabel
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = AppResource.CityLabelText,
                Opacity = 0,
                //IsVisible = false
            };

            _nextButton = new DefaultButton
            {
                Text = AppResource.BtnNextText
            };
            _nextButton.Clicked += NextButton_Clicked;

            _previousButton = new DefaultButton
            {
                IsEnabled = false,
                Text = AppResource.BtnPreviousText
            };
            _previousButton.Clicked += PreviousButton_Clicked;

            _countryListView = new ListView
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Black,
                //IsVisible = false,
                Opacity = 0
            };

            _cityListView = new ListView
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Gray,
                //IsVisible = false,
                Opacity = 0
            };

            var mainStack = new StackLayout
            {
                BackgroundColor = Color.LightGreen
            };
            mainStack.Children.Add(_loadLabel);
            mainStack.Children.Add(_loadCityLabel);
            mainStack.Children.Add(_pickCountryLabel);
            mainStack.Children.Add(_pickCityLabel);
            mainStack.Children.Add(_countryListView);
            mainStack.Children.Add(_cityListView);

            var mainGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Auto)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            mainGrid.Children.Add(_previousButton, 0, 1);
            mainGrid.Children.Add(_nextButton, 1, 1);
            mainGrid.Children.Add(mainStack, 0, 0);
            Grid.SetColumnSpan(mainStack, 2);
            Padding = 10;
            Content = mainGrid;
        }

        private async void PreviousButton_Clicked(object sender, EventArgs e)
        {
            _previousButton.IsEnabled = false;
            await _cityListView.Animate(new FadeOutAnimation());            
            //_cityListView.IsVisible = false;
            await _pickCityLabel.Animate(new FadeOutAnimation());
            //_pickCityLabel.IsVisible = false;

            //_countryListView.IsVisible = true;
            await _countryListView.Animate(new FadeInAnimation());
            //_pickCountryLabel.IsVisible = true;
            await _pickCountryLabel.Animate(new FadeInAnimation());
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await _countryListView.Animate(new FadeOutAnimation());
            //_countryListView.IsVisible = false;
            //_countryListView.Opacity = 0;
            await _pickCountryLabel.Animate(new FadeOutAnimation());
            //_pickCountryLabel.IsVisible = false;
            //_pickCountryLabel.Opacity = 0;
            //_loadCityLabel.IsVisible = true;
            await _loadCityLabel.Animate(new FadeInAnimation());

            await Task.Delay(5000);
            
            await _loadCityLabel.Animate(new FadeOutAnimation());
            //_loadCityLabel.IsVisible = false;

            //_cityListView.IsVisible = true;
            await _cityListView.Animate(new FadeInAnimation());
            //_pickCityLabel.IsVisible = true;
            await _pickCityLabel.Animate(new FadeInAnimation());
            _previousButton.IsEnabled = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            //_loadLabel.IsVisible = true;
            await _loadLabel.Animate(new FadeInAnimation());

            await Task.Delay(5000);
            await _loadLabel.Animate(new FadeOutAnimation());
            //_loadLabel.IsVisible = false;
            //_loadLabel.Opacity = 0;

            //_countryListView.IsVisible = true;
            await _countryListView.Animate(new FadeInAnimation());
            //_pickCountryLabel.IsVisible = true;
            await _pickCountryLabel.Animate(new FadeInAnimation());
        }
    }
}
