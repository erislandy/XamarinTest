using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSearchComponent : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(
                                                              "TapCommand",
                                                              typeof(ICommand),
                                                              typeof(NewSearchComponent),
                                                              null);
        #endregion

        #region Constructors
        public NewSearchComponent()
        {
            InitializeComponent();
            State = "Compressed";
        }
        #endregion

        #region Properties
        public string State { get; set; }
        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }
        #endregion

        #region Methods
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            switch (State)
            {
                case "Compressed":
                    {
                        State = "Expanded";
                        break;
                    }
                case "CompressedSearch":
                    {
                        State = "Expanded";
                        break;
                    }
                case "Expanded":
                    {
                        State = ((entrySearch.Text == null) || (entrySearch.Text.Trim() == string.Empty)) ? "Compressed" : "CompressedSearch";
                        break;
                    }
                default:
                    break;
            }

            VisualStateManager.GoToState(searchComponent, State);
            if (State == "CompressedSearch")
            {
                TapCommand?.Execute(entrySearch.Text.Trim().ToLower());
            }
        }

        #endregion

    }
}