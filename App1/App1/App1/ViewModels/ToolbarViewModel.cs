using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

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
            Languages = new ObservableCollection<LanguageViewModel>(new List<LanguageViewModel>
            {
                new LanguageViewModel { KeyLanguage="en", Description="Ingles", Selected=false},
                new LanguageViewModel { KeyLanguage="al", Description="Aleman", Selected=false},
                new LanguageViewModel { KeyLanguage="fr", Description="Frances", Selected=false},
                new LanguageViewModel { KeyLanguage="es", Description="Español", Selected=true},
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

        public ObservableCollection<string> StatesList
        {
            get;
            set;
        }

        public ObservableCollection<LanguageViewModel> Languages {
            get; 
            set;
        }
    }
}
