using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components.Gavetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GavetasRightUserControl : ContentView
    {
        #region Bindable Property Declarations
        public static readonly BindableProperty DrawerStateProperty = BindableProperty.Create(
                                                           "DrawerState",
                                                           typeof(string),
                                                           typeof(GavetasRightUserControl),
                                                           string.Empty,
                                                          propertyChanged: OnDrawerStateChanged,
                                                          defaultBindingMode: BindingMode.TwoWay);


        public static readonly BindableProperty DescriptionButtonProperty = BindableProperty.Create(
                                                            "DescriptionButton",
                                                            typeof(string),
                                                            typeof(GavetasRightUserControl),
                                                            string.Empty,
                                                            propertyChanged: OnDescriptionButtonChanged);

        public static readonly BindableProperty HandleProperty = BindableProperty.Create(
                                                               "Handle",
                                                               typeof(string),
                                                               typeof(GavetasRightUserControl),
                                                               string.Empty);

        public static readonly BindableProperty DescriptionTitleProperty = BindableProperty.Create(
                                                               "DescriptionTitle",
                                                               typeof(string),
                                                               typeof(GavetasRightUserControl),
                                                               string.Empty,
                                                               propertyChanged: OnDescriptionTitleChanged);

        public static readonly BindableProperty DescriptionValueProperty = BindableProperty.Create(
                                                               "DescriptionValue",
                                                               typeof(string),
                                                               typeof(GavetasRightUserControl),
                                                               string.Empty,
                                                               propertyChanged: OnDescriptionValueChanged);
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(
                                                                  "TapCommand",
                                                                  typeof(ICommand),
                                                                  typeof(GavetasRightUserControl),
                                                                  null);
        public static readonly BindableProperty VerticalSideCommandProperty = BindableProperty.Create(
                                                            "VerticalSideCommand",
                                                            typeof(ICommand),
                                                            typeof(GavetaLeftUserControl),
                                                            null);

        public static readonly BindableProperty MoveVerticalSideProperty = BindableProperty.Create(
                                                                "MoveVerticalSide",
                                                                typeof(bool),
                                                                typeof(GavetaLeftUserControl),
                                                                propertyChanged: MoveVerticalSideMethod);

        #endregion

        public GavetasRightUserControl()
        {
            InitializeComponent();
            this.btn.Clicked += Clicked_Command;
          
        }

        #region Properties
        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }
        public ICommand VerticalSideCommand
        {
            get { return (ICommand)GetValue(VerticalSideCommandProperty); }
            set { SetValue(VerticalSideCommandProperty, value); }
        }
        public string MoveVerticalSide
        {
            get { return (string)GetValue(MoveVerticalSideProperty); }
            set { SetValue(MoveVerticalSideProperty, value); }
        }
        public string DescriptionTitle
        {
            get { return (string)GetValue(DescriptionTitleProperty); }
            set { SetValue(DescriptionTitleProperty, value); }
        }
        public string DescriptionButton
        {
            get { return (string)GetValue(DescriptionButtonProperty); }
            set
            {

                SetValue(DescriptionButtonProperty, value);
            }
        }
        public string DrawerState
        {
            get { return (string)GetValue(DrawerStateProperty); }
            set
            {
                VisualStateManager.GoToState(this.drContainer, value);
                SetValue(DrawerStateProperty, value);
            }
        }
        public string Handle
        {
            get { return (string)GetValue(HandleProperty); }
            set { SetValue(HandleProperty, value); }
        }

        public string DescriptionValue
        {
            get { return (string)GetValue(DescriptionValueProperty); }
            set { SetValue(DescriptionValueProperty, value); }
        }
        #endregion

        #region Private Methods
        private void Clicked_Command(object sender, EventArgs e)
        {
            TapCommand?.Execute(Handle);
        }
       

        static void OnDescriptionTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as GavetasRightUserControl).descriptionTitle.Text = newValue as string;
        }
        static void OnDescriptionButtonChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 
            int number;
            var lbl = (bindable as GavetasRightUserControl).lblButton;
            lbl.Text = newValue as string;
            if (int.TryParse(newValue as string, out number))
            {
                lbl.FontSize = number >= 10 ? 20 : 25;
            }
        }

        static void OnDrawerStateChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as GavetasRightUserControl).DrawerState = newValue as string;
        }
        static void OnDescriptionValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as GavetasRightUserControl).descriptionValue.Text = newValue as string;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            VerticalSideCommand?.Execute(null);
            await this.verticalSide.TranslateTo(100, 0, 200);
            await this.verticalSide.TranslateTo(0, 0, 200);

        }
        static async void MoveVerticalSideMethod(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as GavetasRightUserControl).VerticalSideCommand?.Execute(null);
            await (bindable as GavetasRightUserControl).verticalSide.TranslateTo(100, 0, 200);
            await (bindable as GavetasRightUserControl).verticalSide.TranslateTo(0, 0, 200);
        }
        #endregion


    }
}