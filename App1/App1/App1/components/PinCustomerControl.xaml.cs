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
    public partial class PinCustomerControl : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
                                                        nameof(ImageSource),
                                                        typeof(string),
                                                        typeof(PinCustomerControl),
                                                        string.Empty,
                                                       propertyChanged: OnImageSourceChanged,
                                                       defaultBindingMode: BindingMode.TwoWay);
        #endregion

        #region Properties
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }
        #endregion

        #region Methods
        static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as PinCustomerControl;
            parent.ImageSource = (string) newValue;
            parent.imgButton.Source = Xamarin.Forms.ImageSource.FromUri(new Uri(parent.ImageSource));
        }
        #endregion
        public PinCustomerControl()
        {
            InitializeComponent();
        }
    }
}