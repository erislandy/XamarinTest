using App1.Models;
using App1.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class EventDetailsViewModel : BindableBase
    {
        private string _text;
        public EventDetailsViewModel()
        {
            var types = new string[22]
        {
                "Cita",
                "Cena",
                "Reunión",
                "Conferencia",
                "Seminario",
                "Entrenamiento",
                "Workshop",
                "Clases",
                "Curso",
                "Concierto",
                "Fiesta",
                "Festival",
                "Carnaval",
                "Concurso",
                "Competencia",
                "Ceremonia",
                "Convención ",
                "Banquete",
                "Teatro",
                "Ballet",
                "Show",
                "Circo"
        };
            var list = new List<ItemSourceCollection>();

            foreach (var type in types)
            {
                list.Add(new ItemSourceCollection { Key = type, Selected = false });
            }
            ItemsSource = new ObservableCollection<ItemSourceCollection>(list);
            var list1 = new List<PriceModel>()
            {
                new PriceModel{Price=10.0, Motive="Estudiante"}
              
            };
            Prices = new ObservableCollection<PriceModel>(list1);
        }

        public ObservableCollection<ItemSourceCollection> ItemsSource { get; }

        public string Text { get => _text; set => SetProperty(ref _text, value); }
        public ICommand SelectedTypeCommand { get => new DelegateCommand<object>((selectedItem) => {

            var typeSelected = (ItemSourceCollection)selectedItem;
            foreach (var item in ItemsSource)
            {
                item.Selected = false;
                if(item.Key == typeSelected.Key)
                {
                    item.Selected = true;
                }
            }
        });
        
        }

        public ICommand NewBlankPriceCommand
        {
            get => new DelegateCommand(async () =>
            {
                await Device.InvokeOnMainThreadAsync(() =>
                {

                    Prices.Add(new PriceModel
                    {
                        Price = 5.0,
                        Motive = "Porque si jejejeje"
                    });
                });
            });
        }

        public ObservableCollection<PriceModel> Prices {get; set; }

        public ICommand SaveCommand
        {
            get => new DelegateCommand(() =>
            {
                var text = string.Empty;
                int counter = 0;
                foreach (var price in Prices)
                {
                    counter++;
                    text = $"{text} {counter}: {price.Motive}";
                }
                Text = text;
            });
        }
    }
}
