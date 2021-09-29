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
        public ICommand TapCommand 
        { 
            get => new DelegateCommand(() => {

                Console.Write("Si se hizo tap");
            }); 
        }
    }
}
