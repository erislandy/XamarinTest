using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorComponent : ContentView
    {
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(
                                                                    "Message", 
                                                                    typeof(string), 
                                                                    typeof(ErrorComponent), 
                                                                    string.Empty,
                                                                    propertyChanged: OnMessageChanged);
        public ErrorComponent()
        {
            InitializeComponent();
            
        }

        public string Message 
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        static void OnMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ErrorComponent).label.Text = newValue as string;
        }
    }
}