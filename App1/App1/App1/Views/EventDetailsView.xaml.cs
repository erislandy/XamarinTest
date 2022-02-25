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
    }

}