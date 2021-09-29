using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    public class DialogsViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private string _selectedData;

        public DialogsViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        public string SelectedData
        {
            get => _selectedData;
            set => SetProperty(ref _selectedData, value);
        }

        public ICommand ShowDialogCommand
        {
            get => new DelegateCommand(() =>
            {

                var parameters = new DialogParameters
                {
                    {"handle","1"},
                    { "elements", new List<string>{"15/11/2019","16/11/2021","31/12/2021" } }
                };

                _dialogService.ShowDialog("filterDialog", parameters, (result) =>
                {
                    var handle = result.Parameters.GetValue<string>("handle");
                    var selected = result.Parameters.GetValue<string>("selected");
                    if (selected == null || selected == string.Empty) return;
                    SelectedData = selected;
                });
            });

        }
    }
}