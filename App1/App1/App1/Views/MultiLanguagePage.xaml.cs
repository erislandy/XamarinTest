using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using App1.Resx;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiLanguagePage : ContentPage
    {
        public MultiLanguagePage()
        {
            InitializeComponent();
            string language = Thread.CurrentThread.CurrentUICulture.Name;
            picker.SelectedIndex = language == "en" ? 2 : language == "fr" ? 1 : 0;
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (App.SelectedIndex == picker.SelectedIndex)
                return;
            App.SelectedIndex = picker.SelectedIndex;
            CultureInfo language = new CultureInfo(picker.SelectedIndex == 0 ? "" : picker.SelectedIndex == 1 ? "fr" : "es");
            Thread.CurrentThread.CurrentUICulture = language;
           AppResources.Culture = language;
            Application.Current.MainPage = new NavigationPage(new MultiLanguagePage ());
        }
    }
       
}