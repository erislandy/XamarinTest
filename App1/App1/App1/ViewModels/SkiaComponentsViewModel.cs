using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class SkiaComponentsViewModel: BindableBase
    {
        private string _title;
        private string _description;
        private string _iconButton;
        private string _drawerState;
        private string _handle;
        private bool _isOpened;
        private bool _isCreatedByUser;
        public SkiaComponentsViewModel()
        {
            Title = string.Empty;
            Description = string.Empty;
            IconButton = string.Empty;
            DrawerState = "Normal";
            Handle = "";
            IsOpened = true;
            IsCreatedByUser = false;
        }
        public string Title { 
            get => _title; 
            set => SetProperty(ref _title, value); 
        }
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        public string IconButton
        {
            get => _iconButton;
            set => SetProperty(ref _iconButton, value);
        }
        public string DrawerState
        {
            get => _drawerState;
            set => SetProperty(ref _drawerState, value);
        }
        public string Handle
        {
            get => _handle;
            set => SetProperty(ref _handle, value);
        }
        public bool IsCreatedByUser
        {
            get => _isCreatedByUser;
            set => SetProperty(ref _isCreatedByUser, value);
        }
        public ICommand SaveCommand
        {
            get => new DelegateCommand(() => {

                Title = "Concierto de jazz";
                Description = "12/22/2021";
                IsCreatedByUser = !IsCreatedByUser;
            });
        }
        public ICommand SwitchCommand
        {
            get => new DelegateCommand(() => {

                IsOpened = !IsOpened;
            });
        }

        public bool IsOpened {
            get => _isOpened;
            set => SetProperty(ref _isOpened, value);
        }

    }
}
