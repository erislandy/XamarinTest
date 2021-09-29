using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class SearchViewModel: BindableBase
    {
        private string _descriptionTitle;
        private string _descriptionButton;
        private string _leftValue;
        private string _rightValue;
        private bool _moveLeftSide;
        public SearchViewModel()
        {
            DescriptionButton = "8";
            _rightValue = "";
        }
        
        public ICommand ClearAllCommand
        {
            get => new DelegateCommand(() =>
            {
                MoveLeftSide = !MoveLeftSide;
            });

        }
        public ICommand LeftCommand {
            get => new DelegateCommand(() =>
            {
                LeftValue = "Nov 15,2021";
            }); 
            
        }
        public ICommand RightCommand
        {
            get => new DelegateCommand(() => {
                RightValue = RightValue == "" ? "5" : (int.Parse(RightValue) + 1).ToString();
            }); 
        }

        public ICommand ClearCommand
        {
            get => new DelegateCommand(() => {
                DescriptionButton = "15";
            });
        }

        public string DescriptionTitle
        {
            get => _descriptionTitle;
            set => SetProperty(ref _descriptionTitle, value);
        }

        public string DescriptionButton {
            get => _descriptionButton;
            set => SetProperty(ref _descriptionButton, value);
        }
        public string LeftValue
        {
            get => _leftValue;
            set => SetProperty(ref _leftValue, value);
        }
        
        public string RightValue
        {
            get => _rightValue;
            set => SetProperty(ref _rightValue, value);
        }
        public bool MoveLeftSide
        {
            get => _moveLeftSide;
            set => SetProperty(ref _moveLeftSide, value);
        }
    }
}
