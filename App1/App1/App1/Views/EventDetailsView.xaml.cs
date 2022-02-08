using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Navigation;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.UI.Views;
namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailsView : ContentPage
	{
		public EventDetailsView ()
		{
			InitializeComponent ();
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnPlayButtonClicked;
            this.playButton.GestureRecognizers.Add(tapGesture);
            this.plusIcon.Text = "\uf055";

        }
        void OnPlayButtonClicked(object sender, EventArgs args)
        {
            if (videoXCT.CurrentState == MediaElementState.Stopped ||
                videoXCT.CurrentState == MediaElementState.Paused)
            {
                videoXCT.Play();
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var imageAndVideoTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.Android, new[] { "image/png","image/jpeg","video/*" } }
            });
            var pickResult = await FilePicker.PickAsync(options: new PickOptions
            { FileTypes = imageAndVideoTypes, PickerTitle = "Escoge un video o una imagen" });

            if (pickResult != null)
            {
                var fullPath = pickResult.FullPath;
                var split = fullPath.Split('.');
                var isImage = split[split.Length - 1] == "png" || split[split.Length - 1] == "jpg" ? true : false;
                UploadMainFileCommand?.Execute(new NavigationParameters {
                     { "fullPath",fullPath },
                     { "isImage",isImage }
                 });
            }
        }

        #region Bindable Properties
        public static readonly BindableProperty PickPhotoCommandProperty = BindableProperty.Create(
            "PickPhotoCommand",
            typeof(ICommand),
            typeof(EventDetailsView),
            null);
        public static readonly BindableProperty UploadMainFileCommandProperty = BindableProperty.Create(
            "UploadMainFileCommand",
            typeof(ICommand),
            typeof(EventDetailsView),
            null);

        #endregion

        public ICommand PickPhotoCommand
        {
            get => (ICommand)GetValue(PickPhotoCommandProperty);
            set => SetValue(PickPhotoCommandProperty, value);
        }
        public ICommand UploadMainFileCommand
        {
            get => (ICommand)GetValue(UploadMainFileCommandProperty);
            set => SetValue(UploadMainFileCommandProperty, value);
        }


    }
}