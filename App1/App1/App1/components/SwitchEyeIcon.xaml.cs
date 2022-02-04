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
    public partial class SwitchEyeIcon : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty IsOpenedProperty = BindableProperty.Create(
                                                          "IsOpened",
                                                          typeof(bool),
                                                          typeof(SwitchEyeIcon),
                                                          null,
                                                         propertyChanged: OnIsOpenedMethod,
                                                         defaultBindingMode: BindingMode.TwoWay);

        #endregion
        public SwitchEyeIcon()
        {
            InitializeComponent();
        }

        public bool IsOpened
        {
            get { return (bool)GetValue(IsOpenedProperty); }
            set
            {
               SetValue(IsOpenedProperty, value);
            }
        }

        static void OnIsOpenedMethod(BindableObject bindable, object oldValue, object newValue)
        {
            var isOpened = (bool)newValue;
            (bindable as SwitchEyeIcon).eyeOpened.IsVisible = isOpened;
            (bindable as SwitchEyeIcon).eyeClosed.IsVisible = !isOpened;
        }
    }
}