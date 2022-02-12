using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace App1.Converter
{
    public class PathKeepVerticalSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterString = (string)parameter;
            var width = (double)value;
            width = width > 395 || width < 38 ? 395 : width;
            var numberConverted = width - 38;
            var converter = new PathGeometryConverter();

            if (parameterString == "bottomPath")
            {
                var string1 = 384.16;
                var string2 = 363;

                var numConverted1 = width - (395 - 384.16);
                var numeConverted2 = width - (395 - 363);
                var bottomPath = "m 5.42 28 h 384.16 a 16 16 0 0 1 -10.58 4 h -363 a 16 16 0 0 1 -10.58 -4";
                var bottomPathConverted = bottomPath.Replace(string1.ToString(), numConverted1.ToString())
                                                    .Replace(string2.ToString(), numeConverted2.ToString());
                return converter.ConvertFromInvariantString(bottomPathConverted);

            }

            if(parameterString == "precioPath")
            {
                var dataPrecio = "m 0 16 a 16 16 0 0 1 16 -16 h 97 a 32 32 0 0 1 32 32 h -129 a 16 16 0 0 1 -16 -16";
                var valueStringPrecio = 97;
                var valueConverted = 0.442*width - 77.59;

                var valueStringPrecio2 = 129;
                var valueConverted2 = valueConverted + 32;
                var dataPrecioConverted = dataPrecio.Replace(valueStringPrecio.ToString(), valueConverted.ToString())
                                                    .Replace(valueStringPrecio2.ToString(), valueConverted2.ToString());
           
                return converter.ConvertFromInvariantString(dataPrecioConverted);
            }
            var valueInString = 363;
            
            var data = "m 0 16 a 16 16 0 0 1 16 -16 h 363 a 16 16 0 0 1 0 32 h -363 a 16 16 0 0 1 -16 -16";
            var daraConverted = data.Replace(valueInString.ToString(), numberConverted.ToString());
            return converter.ConvertFromInvariantString(daraConverted);
       

            

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
