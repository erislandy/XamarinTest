using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components.Gavetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZoomUserControl : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty PlusCommandProperty = BindableProperty.Create(
                                                                 "PlusCommand",
                                                                 typeof(ICommand),
                                                                 typeof(ZoomUserControl),
                                                                 null);
        public static readonly BindableProperty MinusCommandProperty = BindableProperty.Create(
                                                                "MinusCommand",
                                                                typeof(ICommand),
                                                                typeof(ZoomUserControl),
                                                                null);
        #endregion

        #region Constructors
        public ZoomUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public ICommand PlusCommand
        {
            get { return (ICommand)GetValue(PlusCommandProperty); }
            set { SetValue(PlusCommandProperty, value); }
        }
        public ICommand MinusCommand
        {
            get { return (ICommand)GetValue(MinusCommandProperty); }
            set { SetValue(MinusCommandProperty, value); }
        }
        #endregion
        #region Methods
        private void PlusTapped(object sender, EventArgs e)
        {
            PlusCommand?.Execute(null);
        }
        private void MinusTapped(object sender, EventArgs e)
        {
            MinusCommand?.Execute(null);
        }

        private async void CenterTapped(object sender, EventArgs e)
        {
            if (btnPlus.IsVisible == false)
            {
                var resizeBars = new Animation(v => rectangleBars.HeightRequest = v, 0, 112);
                btnPlus.IsVisible = true;
                btnMinus.IsVisible = true;
                rectangleBars.IsVisible = true;
                await Task.WhenAll(
                    btnPlus.FadeTo(1, 300),
                    btnMinus.FadeTo(1, 300),
                    rectangleBars.FadeTo(1, 300),
                    Task.Run(() => resizeBars.Commit(this, "resizeBars", 16, 300))
                    );
            } else 
            {
                var resizeBarsBack = new Animation(v => rectangleBars.HeightRequest = v, 112, 0);
               
                await Task.WhenAll(
                    btnPlus.FadeTo(0, 300),
                    btnMinus.FadeTo(0, 300),
                    rectangleBars.FadeTo(0, 300),
                    Task.Run(() => resizeBarsBack.Commit(this, "resizeBarsBack", 16, 300))
                    );
                btnPlus.IsVisible = false;
                btnMinus.IsVisible = false;
                rectangleBars.IsVisible = false;
            }
        }
        #endregion

    }
}