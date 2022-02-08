using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ToolbarViewModel: BindableBase
    {
        private string _text;
        private bool _isExpanded;
        private string _activatedWindow;
        public ToolbarViewModel()
        {
            Text = "Please touch buttons";
            IsExpanded = true;
            ActivatedWindow = "search";
            StatesList = new ObservableCollection<string>(new List<string>
            {
                "Expanded",
                "Compressed",
                "Opened"
            });
            Languages = new ObservableCollection<ItemCollectionViewModel>(new List<ItemCollectionViewModel>
            {
                new ItemCollectionViewModel { Key="en", Description="Ingles", Selected=false},
                new ItemCollectionViewModel { Key="al", Description="Aleman", Selected=false},
                new ItemCollectionViewModel { Key="fr", Description="Frances", Selected=false},
                new ItemCollectionViewModel { Key="es", Description="Español", Selected=true},
            });
            CurrencyList = new ObservableCollection<ItemCollectionViewModel>(new List<ItemCollectionViewModel>
            {
                new ItemCollectionViewModel { Key="USD", Description="Dolar", Selected=false},
                new ItemCollectionViewModel { Key="CHF", Description="Franco Suizo", Selected=false},
                new ItemCollectionViewModel { Key="EUR", Description="Frances", Selected=true},
            });
        }
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        public ICommand UndoCommand
        {
            get => new DelegateCommand(() =>
            {
                Text = "I touch Undo button";
            });

        }
        public ICommand SearchCommand
        {
            get => new DelegateCommand(() =>
            {
                Text = "I touch search button";
            });

        }
        public bool IsExpanded { 
            get => _isExpanded; 
            set => SetProperty(ref _isExpanded, value); 
        }
        public string ActivatedWindow
        {
            get => _activatedWindow;
            set => SetProperty(ref _activatedWindow, value);
        }
        public ICommand ChangeStateCommand
        {
            get => new DelegateCommand(() =>
            {
                ActivatedWindow = "create";
                IsExpanded = !IsExpanded;
            });
            
        }
        public ICommand SelectedCurrencyCommand
        {
            get => new DelegateCommand<ItemCollectionViewModel>((ItemCollectionViewModel model) =>
            {
                foreach (var currency in CurrencyList)
                {
                    _ = currency.Key == model.Key ? currency.Selected = true : currency.Selected = false;
                }
            });

        }
        public ICommand SelectedLanguageCommand
        {
            get => new DelegateCommand<ItemCollectionViewModel>((ItemCollectionViewModel model) =>
            {
                foreach (var language in Languages)
                {
                    _ = language.Key == model.Key ? language.Selected = true : language.Selected = false;
                }
            });

        }
        public ICommand LogoutCommand
        {
            get => new DelegateCommand<string>((string key) =>
            {
                Application.Current.MainPage.DisplayAlert("Logout", "You are close session", "ok");
            });

        }



        public ObservableCollection<string> StatesList
        {
            get;
            set;
        }

        public ObservableCollection<ItemCollectionViewModel> Languages {
            get; 
            set;
        }
        public ObservableCollection<ItemCollectionViewModel> CurrencyList
        {
            get;
            set;
        }
    }
}
