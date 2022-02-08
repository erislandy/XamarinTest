using App1.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class EventDetailsViewModel : BindableBase
    {
        private bool _loading;
        private string _mainVideo;
        private string _mainPicture;
        private IUploadServices _uploadServices;
        private bool _isImageDownloaded;
        private bool _isVideoDownloaded;

        public EventDetailsViewModel(IUploadServices uploadServices)
        {
            _uploadServices = uploadServices;
        }
        public bool IsVideoDownloaded
        {
            get => _isVideoDownloaded;
            set => SetProperty(ref _isVideoDownloaded, value);
        }
        public bool IsImageDownloaded
        {
            get => _isImageDownloaded;
            set => SetProperty(ref _isImageDownloaded, value);
        }
        public string Username { get; set; }
        public string MainVideo
        {
            get => _mainVideo;
            set => SetProperty(ref _mainVideo, value);
        }
        public string MainPicture
        {
            get => _mainPicture;
            set => SetProperty(ref _mainPicture, value);
        }
        public bool Loading
        {
            get =>_loading;
            set => SetProperty(ref _loading, value);
        }
        public ICommand UploadMainFileCommand
        {
            get => new DelegateCommand<NavigationParameters>(async (NavigationParameters parameters) =>
            {

                var fullPath = parameters.GetValue<string>("fullPath");
                var isImage = parameters.GetValue<bool>("isImage");
                Loading = true;
                var filename = fullPath.Split('/')[fullPath.Split('/').Length - 1];

                if (isImage)
                {
                    string keyBucket = Username + "/profile-photo/" + filename;
                    _ = await _uploadServices.UploadPhoto(
                        imagePath: fullPath,
                        keyBucket: keyBucket);
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        IsImageDownloaded = true;
                        IsVideoDownloaded = false;
                        MainPicture = GetImageURL(keyBucket);
                        //TODO update events with MainPicture

                        Loading = false;
                    });
                }
                else
                {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        string keyBucket = Username + "/profile-file/" + filename;
                        var urlFile = await _uploadServices.UploadFile(fullPath, keyBucket);
                        IsVideoDownloaded = true;
                        IsImageDownloaded = false;
                        MainVideo = urlFile.Trim().Replace(" ", "+");
                        //Update event with main video
                        Loading = false;
                    });

                }

            });
        }
        public ICommand ClearMediaCommand
        {
            get => new DelegateCommand<string>(async (string param) =>
            {

                MainPicture = " ";
                MainVideo = " ";

                //TODO update event

                IsVideoDownloaded = false;
                IsImageDownloaded = false;

            });
        }
        private static string CloudFrontUrl => "https://dr0yzykqggsp4.cloudfront.net";
        public static string Bucket => "evemundo-uploads";
        public static string FolderFilesBucket => "app-mobile/";
        private string HttpUrlBucket => "evemundo-uploads.s3.eu-central-1.amazonaws.com/";
        private static string EncodeBTOA(string toEncode)
        {
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = Convert.ToBase64String(bytes);
            return toReturn;
        }
        public string GetImageURL(string img)
        {
            double width = DeviceDisplay.MainDisplayInfo.Width;
            width = (int)width / 100 * 100;
            //int width = 720;
            //Doc on https://docs.aws.amazon.com/solutions/latest/serverless-image-handler/deployment.html#step2
            string imageRequest = JsonConvert.SerializeObject(new
            {
                bucket = Bucket,
                key = FolderFilesBucket + img,
                edits = new { resize = (width, fit: "cover") },
            });
            return $"{CloudFrontUrl}/{EncodeBTOA(imageRequest)}";
        }


    }
}
