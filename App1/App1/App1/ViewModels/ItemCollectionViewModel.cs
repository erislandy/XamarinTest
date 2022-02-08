using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    public class ItemCollectionViewModel: BindableBase
    {
        private string _key;
        private string _description;
        private bool _selected;

        public string Key 
        { 
            get => _key; 
            set => SetProperty(ref _key, value); 
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
