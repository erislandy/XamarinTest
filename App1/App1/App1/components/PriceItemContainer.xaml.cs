using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceItemContainer : ContentView
    {
        #region Bindables Properties
        public static readonly BindableProperty ClearingProperty = BindableProperty.Create(
                                                          "Clearing",
                                                          typeof(bool),
                                                          typeof(PriceItemContainer),
                                                          false,
                                                         propertyChanged: OnClearingChanged,
                                                         defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty WidthFrameProperty = BindableProperty.Create(
                                                          "WidthFrame",
                                                          typeof(double),
                                                          typeof(PriceItemContainer),
                                                          395.00,
                                                         propertyChanged: OnWidthFrameChanged,
                                                         defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty MargingFromLeftProperty = BindableProperty.Create(
                                                         "MargingFromLeft",
                                                         typeof(double),
                                                         typeof(PriceItemContainer),
                                                         0.00,
                                                        propertyChanged: OnMargingFromLeftChanged,
                                                        defaultBindingMode: BindingMode.TwoWay);

        #endregion
        #region Properties

        public int TranslationVerticalBar { get; set; }
        public double WidthFrame
        {
            get { return (double)GetValue(WidthFrameProperty); }
            set
            {
                SetValue(WidthFrameProperty, value);
            }
        }
        public double MargingFromLeft
        {
            get { return (double)GetValue(MargingFromLeftProperty); }
            set
            {
                SetValue(MargingFromLeftProperty, value);
            }
        }
        public bool Clearing
        {
            get { return (bool)GetValue(ClearingProperty); }
            set
            {
                SetValue(ClearingProperty, value);
            }
        }
        #endregion

        #region Methods
        static void OnWidthFrameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as PriceItemContainer;
            parent.frameContainer1.WidthRequest = (double)newValue;
            parent.WidthFrame = (double)newValue;
        }
        static void OnMargingFromLeftChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as PriceItemContainer;
            parent.verticalbar.Margin = new Thickness(0, 0, (double)newValue, 0);
            parent.MargingFromLeft = (double)newValue;
        }
        static void OnClearingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as PriceItemContainer;
            parent.Clearing = (bool)newValue;
        }
        #endregion

        #region Constructors

        public PriceItemContainer()
        {
            InitializeComponent();

        }
        #endregion

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await verticalbar.Animate(new TranslateToAnimation
                {
                    TranslateX = -1 * TranslationVerticalBar,
                    Duration = "400",
                    Easing = EasingType.CubicInOut,

                });
                Clearing = true;
                await verticalbar.Animate(new TranslateToAnimation
                {
                    TranslateX = 0,
                    Duration = "400",
                    Easing = EasingType.CubicInOut,

                });
                Clearing = false;
            });

        }

    }
}