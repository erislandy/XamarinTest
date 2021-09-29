using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class SwipePageViewModel:BindableBase
    {
        public SwipePageViewModel()
        {
            IsVisible = true;
        }
        private bool _isVisible;
        public ICommand SwipeCommand 
        {
            get => new DelegateCommand(() => {

                IsVisible = !IsVisible;
            }); 
           
        }

        public bool IsVisible 
        { 
            get => _isVisible; 
            set => SetProperty(ref _isVisible, value); 
        }
    }
}
