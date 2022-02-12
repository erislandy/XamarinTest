using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{

    public class ItemSourceCollection : BindableBase
    {
        private string _key;
        private bool _selected;
        public string Key { 
            get => _key; 
            set => SetProperty(ref _key, value); 
        }
        public bool Selected {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }
    }
}
