using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    public class LanguageViewModel: BindableBase
    {
        private string _keyLanguage;
        private string _description;
        private bool _selected;

        public string KeyLanguage 
        { 
            get => _keyLanguage; 
            set => SetProperty(ref _keyLanguage, value); 
        }
        public string Description {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        public bool Selected {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }
    }
}
