using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Helper
{
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class LazyPage<T> : ContentPage where T : View, new()
    {
        public LazyPage()
        {
            this.Visual = VisualMarker.Material;
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            var label = new Label
            {
                Text = "Loading...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black
            };
            var indicator = new ActivityIndicator
            {
                IsRunning = true,
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            var grid = new Grid();
            grid.Children.Add(label);
            grid.Children.Add(indicator);
            var contentView = new ContentView
            {
                BackgroundColor = Color.Gray,
                Opacity = 0.5f,
                Content = grid,
            };
            this.Content = contentView;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = true;
            Task.Run(() =>
            {
                var view = new T();
                Device.InvokeOnMainThreadAsync(() =>
                {
                    Content = view;
                    view.BindingContext = BindingContext;
                    IsBusy = false;
                });
            });
        }
    }
}
