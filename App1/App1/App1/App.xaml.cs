using App1.Dialogs;
using App1.ViewModels;
using App1.Views;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App 
    {
        public App() : this(null) { }
        public App(IPlatformInitializer initializer):base(initializer){}

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<SearchView, SearchViewModel>();
            containerRegistry.RegisterForNavigation<ToolbarView, ToolbarViewModel>();
            containerRegistry.RegisterForNavigation<SkiaComponentsView, SkiaComponentsViewModel>();
            containerRegistry.RegisterForNavigation<AnimationViewPage>();
            containerRegistry.RegisterForNavigation<DialogsView,DialogsViewModel>();
            containerRegistry.RegisterDialog<FilterSelection, FilterSelectionViewModel>("filterDialog");
            containerRegistry.RegisterForNavigation<MapElementsView, MapsElementsViewModel>();

            //    containerRegistry.RegisterForNavigation<SwipePage, SwipePageViewModel>();

        }

    }
}
