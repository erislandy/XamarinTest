using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.TabView;
using Xam.TabView.Control;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationViewPage : ContentPage
    {
        string url = "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3";



        public AnimationViewPage()
        {
            InitializeComponent();
        

        }
       
    }
}