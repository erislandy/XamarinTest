using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App1.components.Gavetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UndoUserControl : ContentView
    {
        public static readonly BindableProperty UndoButtomCommandProperty = BindableProperty.Create(
                                                                "UndoButtomCommand",
                                                                typeof(ICommand),
                                                                typeof(UndoUserControl),
                                                                null);
        public UndoUserControl()
        {
            InitializeComponent();
        }
        public ICommand UndoButtomCommand
        {
            get { return (ICommand)GetValue(UndoButtomCommandProperty); }
            set { SetValue(UndoButtomCommandProperty, value); }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            UndoButtomCommand?.Execute(null);
        }
    }
}