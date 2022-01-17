using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class AutocompleteElement
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class MapsElementsViewModel : BindableBase
    {
        private string _text;
        private ObservableCollection<AutocompleteElement> _itemsSource;

        public MapsElementsViewModel()
        {
            ItemsSource = new ObservableCollection<AutocompleteElement>()
            {
                new AutocompleteElement{Icon="1", Name="Evento", Value="Natalia"},
                 new AutocompleteElement{Icon="2", Name="Evento", Value="Erislandy"},
                  new AutocompleteElement{Icon="3", Name="Evento", Value="Erick"},
                   new AutocompleteElement{Icon="4", Name="Evento", Value="Roxana"}
            };
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

        public ObservableCollection<AutocompleteElement> ItemsSource
        {
            get => _itemsSource;
            set => SetProperty(ref _itemsSource, value);
        }
    }
}
