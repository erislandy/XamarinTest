using App1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPickerComponent : ContentView

    {
        public static readonly BindableProperty IsModalOpenProperty = BindableProperty.Create(
                                                                            nameof(IsModalOpen),
                                                                            typeof(bool),
                                                                            typeof(ModalPickerComponent),
                                                                            false, 
                                                                            BindingMode.TwoWay,
                                                                            propertyChanged: IsModalChanged);
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
                                                                            nameof(SelectedItem), 
                                                                            typeof(object), 
                                                                            typeof(ModalPickerComponent), 
                                                                            null, BindingMode.TwoWay);

        public static readonly BindableProperty SelectedItemCommandProperty = BindableProperty.Create(
                                                                            nameof(SelectedItemCommand), 
                                                                            typeof(ICommand),
                                                                            typeof(ModalPickerComponent),
                                                                            default(ICommand));

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
                                                                        nameof(ItemsSource), 
                                                                        typeof(IEnumerable), 
                                                                        typeof(ModalPickerComponent), 
                                                                        new List<object>(),
                                                                        defaultBindingMode: BindingMode.TwoWay,
                                                                        propertyChanged: ItemsSourceChanged);
        public bool IsModalOpen
        {
            get { return (bool) GetValue(IsModalOpenProperty); }
            set { SetValue(IsModalOpenProperty, value); }
        }
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public ICommand SelectedItemCommand
        {
            get { return (ICommand)GetValue(SelectedItemCommandProperty); }
            set { SetValue(SelectedItemCommandProperty, value); }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = (ModalPickerComponent)bindable;
            parent.ItemsSource = (IEnumerable)newValue;
            parent.collection.ItemsSource = parent.ItemsSource;

        }
        private static async void IsModalChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = (ModalPickerComponent)bindable;
            var isModal = (bool)newValue;
            parent.IsModalOpen = isModal;
            if (isModal)
            {
                parent.IsVisible = true;
                parent.absolute.VerticalOptions = LayoutOptions.FillAndExpand;
                parent.modalContainer.IsVisible = true;
                await Task.Delay(100);
                await parent.modalContainer.FadeTo(1, 1000);
                
            }else
            {
                await parent.modalContainer.FadeTo(0, 200);
                parent.modalContainer.IsVisible = false;
                parent.IsVisible = false;
                parent.absolute.VerticalOptions = LayoutOptions.EndAndExpand;
            }
          

        }
       

        public ModalPickerComponent()
        {
            InitializeComponent();
        }

       

        private void SelectedItemMethod(object sender, EventArgs e)
        {
            SelectedItem = (sender as StackLayout).BindingContext;
            SelectedItemCommand?.Execute(SelectedItem);
            IsModalOpen = false;
        }

        private async void CloseModalTapped(object sender, EventArgs e)
        {
            await modalContainer.FadeTo(0, 500);
            await Task.Delay(500);
            IsModalOpen = false;
        }
    }
}