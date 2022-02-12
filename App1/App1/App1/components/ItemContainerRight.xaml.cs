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
    public partial class ItemContainerRight : ContentView
    {
        public ItemContainerRight()
        {
            InitializeComponent();
        }
        #region Bindables Properties
        public static readonly BindableProperty WidthFrameProperty = BindableProperty.Create(
                                                          "WidthFrame",
                                                          typeof(double),
                                                          typeof(ItemContainerRight),
                                                          395.00,
                                                         propertyChanged: OnWidthFrameChanged,
                                                         defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty MargingFromRightProperty = BindableProperty.Create(
                                                         "MargingFromRight",
                                                         typeof(double),
                                                         typeof(ItemContainerRight),
                                                         0.00,
                                                        propertyChanged: OnMargingFromRightChanged,
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
        public double MargingFromRight
        {
            get { return (double)GetValue(MargingFromRightProperty); }
            set
            {
                SetValue(MargingFromRightProperty, value);
            }
        }
        #endregion

        #region Methods
        static void OnWidthFrameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainerRight;
            parent.frameContainer1.WidthRequest = (double)newValue;
            parent.WidthFrame = (double)newValue;
        }
        static void OnMargingFromRightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainerRight;
            parent.verticalbar.Margin = new Thickness((double)newValue, 0, 0, 0);
            parent.MargingFromRight = (double)newValue;
        }
        #endregion

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                await verticalbar.Animate(new TranslateToAnimation
                {
                    TranslateX = TranslationVerticalBar,
                    Duration = "400",
                    Easing = EasingType.CubicInOut,

                });
                await verticalbar.Animate(new TranslateToAnimation
                {
                    TranslateX = 0,
                    Duration = "400",
                    Easing = EasingType.CubicInOut,

                });
            });

        }


    }
}