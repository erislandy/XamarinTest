using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components
{
    using Xamarin.Forms;
    class DefaultMarker: ContentView
    {
        public DefaultMarker(int width)
        {

            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(2*width)}
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(width)}
                }
            };
            grid.Children.Add(new DefaultMarkerGoogleMap());

            Content = grid;

        }
    }
}
