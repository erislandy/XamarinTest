using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class MapsElementsViewModel : BindableBase
    {
        private string _text;

        public MapsElementsViewModel()
        {
          
        }
        public string Text 
        { 
            get => _text; 
            set => SetProperty(ref _text, value); 
        }

        public ICommand SearchCommand 
        { 
            get => new DelegateCommand<string>((text)=> {
                Text = text;
            }); 
           
        }
    }
}
