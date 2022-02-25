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
    public partial class ItemContainer : ContentView
    {

        #region Bindables Properties
        public static readonly BindableProperty TextErrorProperty = BindableProperty.Create(
                                                          nameof(TextError),
                                                          typeof(string),
                                                          typeof(ItemContainer),
                                                          string.Empty,
                                                         propertyChanged: OnTextErrorChanged,
                                                         defaultBindingMode: BindingMode.OneWay);
        public static readonly BindableProperty IsInvalidProperty = BindableProperty.Create(
                                                          nameof(IsInvalid),
                                                          typeof(bool),
                                                          typeof(ItemContainer),
                                                          false,
                                                         propertyChanged: OnIsInvalidChanged,
                                                         defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty ClearingProperty = BindableProperty.Create(
                                                          "Clearing",
                                                          typeof(bool),
                                                          typeof(ItemContainer),
                                                          false,
                                                         propertyChanged: OnClearingChanged,
                                                         defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty WidthFrameProperty = BindableProperty.Create(
                                                          "WidthFrame",
                                                          typeof(double),
                                                          typeof(ItemContainer),
                                                          395.00,
                                                         propertyChanged: OnWidthFrameChanged,
                                                         defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty MargingFromLeftProperty = BindableProperty.Create(
                                                         "MargingFromLeft",
                                                         typeof(double),
                                                         typeof(ItemContainer),
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
        public string TextError
        {
            get { return (string)GetValue(TextErrorProperty); }
            set
            {
                SetValue(TextErrorProperty, value);
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
        public bool IsInvalid
        {
            get { return (bool)GetValue(IsInvalidProperty); }
            set
            {
                SetValue(IsInvalidProperty, value);
            }
        }
        #endregion

        #region Methods
        static void OnWidthFrameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainer;
            parent.frameContainer1.WidthRequest = (double)newValue;
            parent.WidthFrame = (double)newValue;
        }
        static void OnMargingFromLeftChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainer;
            parent.verticalbar.Margin = new Thickness(0, 0, (double)newValue, 0);
            parent.MargingFromLeft = (double)newValue;
        }
        static void OnClearingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainer;
            parent.Clearing = (bool)newValue;
        }
        static void OnTextErrorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainer;
            parent.TextError = (string)newValue;
            
          
        }
        static  async void OnIsInvalidChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = bindable as ItemContainer;
            parent.IsInvalid = (bool)newValue;

            if(parent.IsInvalid)
            {
                await Task.Delay(300);
                
            }
            parent.lblTextError.IsVisible = parent.IsInvalid;



        }
        #endregion

        #region Constructors

        public ItemContainer()
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