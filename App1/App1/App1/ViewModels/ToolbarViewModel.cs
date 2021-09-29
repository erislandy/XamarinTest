using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class ToolbarViewModel: BindableBase
    {
        private string _text;
        
        public ToolbarViewModel()
        {
            Text = "Please touch buttons";
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
    }
}
