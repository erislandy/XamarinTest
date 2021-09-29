using App1.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace App1.Dialogs
{
    public class FilterSelectionViewModel : BindableBase, IDialogAware
    {
        private ObservableCollection<ElementList> _elements;
        public event Action<IDialogParameters> RequestClose;
        public FilterSelectionViewModel()
        {
            Elements = new ObservableCollection<ElementList>();
        }
        

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var handle = parameters.GetValue<string>("handle");
            var elements = parameters.GetValue <List<string>>("elements");
            Handle = handle;
            Elements = new ObservableCollection<ElementList>(elements.Select(e => new ElementList { 
                Element = e,
                Icon = "5"
            }).ToList());
        }

        public ICommand CloseCommand {
            get => new DelegateCommand(() =>
            {
                RequestClose(null);
            });
        }

        public ICommand SelectedCommand
        {
            get => new DelegateCommand<ElementList>((selected) =>
            {
                var parameters = new DialogParameters
                {
                    {"handle",Handle},
                    { "selected", selected.Element }
                };
                RequestClose(parameters);
            });
        }

        public ObservableCollection<Models.ElementList> Elements {
            get => _elements;
            set => SetProperty(ref _elements, value);
            
        }

        public string Handle 
        {
            get; set;
        }

    }
}
