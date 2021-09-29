using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components.Gavetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchButtomUserControl : ContentView
    {
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
                                                                "SearchCommand",
                                                                typeof(ICommand),
                                                                typeof(SearchButtomUserControl),
                                                                null);
        public SearchButtomUserControl()
        {
            InitializeComponent();
        }
        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SearchCommand?.Execute(null);
        }
    }
}