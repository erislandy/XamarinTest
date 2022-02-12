using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.UI.Views;
using App1.Models;
using App1.ViewModels;
using System.Threading.Tasks;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailsView : ContentPage
	{
		public EventDetailsView ()
		{
			InitializeComponent ();
           
        }
        private void OpenCloseMethod(object sender, EventArgs e)
        {

        }

       
        private async void PriceContainer_Tapped(object sender, EventArgs e)
        {
            await Device.InvokeOnMainThreadAsync(async() =>
            {
                plusIcon.IsVisible = !plusIcon.IsVisible;
                var count = prices.ItemsSource.Cast<object>().Count();
                count = count > 3 ? 3 : count;
                var newHeightRequest = 40 * count + 20;

                if (plusIcon.IsVisible)
                {
                    var resizeModal = new Animation(v => modalPrice.HeightRequest = v, 0, newHeightRequest);
                    await Task.Run(() => resizeModal.Commit(this, "resize", 16, 300));
                    await Task.Delay(300);
                    prices.IsVisible = true;
                    await prices.FadeTo(1, 300);
                }
                else
                {
                    await prices.FadeTo(0, 300);
                    prices.IsVisible = false;
                    var resizeModalInverter = new Animation(v => modalPrice.HeightRequest = v, newHeightRequest, 0);
                    await Task.Run(() => resizeModalInverter.Commit(this, "resize", 16, 300));

                }
            });
           

        }

        private async void plus_tapped(object sender, EventArgs e)
        {
            var oldHeight = modalPrice.HeightRequest;
            var newHeight =oldHeight  + 40;
            newHeight = newHeight > 140 ? 140 : newHeight;
            var resizeNewprice = new Animation(v => modalPrice.HeightRequest = v, oldHeight, newHeight);
            await Task.Run(() => resizeNewprice.Commit(this, "resize", 16, 300));
            var count = prices.ItemsSource.Cast<object>().Count();
            prices.ScrollTo(count - 1);
        }
    }

}