using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.components
{
    public class Marker : ContentView
    {
        public Marker(int with, int height, string name)
        {
         
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(height)}
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(with)}
                }
            };
            grid.Children.Add(new CounterGoogleMap(name));

            Content = grid;

        }
    }
}
