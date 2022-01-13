using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{
    public static class FixedDrawersDataType
    {
        public const string FECHA = "FECHA";
        public const string HORA = "HORA";
        public const string PRECIO = "PRECIO";
        public const string FIN_DE_SEMANA = "FIN_DE_SEMANA";

        public static string getType(FilterType filterType)
        {
            var arrayConst = new string[] { FECHA, HORA, PRECIO, FIN_DE_SEMANA };
            return arrayConst[(int)filterType];
        }
    }

    public enum FilterType
    {
       
        DATE,
        HOUR, 
        PRICE,
        TEXT,
        WEEKEND,
        EVENT_TYPE,
        NULL,
        EVENT_TOPIC
    }

    public static class FilterTypeNames
    {
        public static Dictionary<FilterType, string> DrawerNames =>
                                new Dictionary<FilterType, string>
                                {
                                    {FilterType.DATE, "Fecha" },
                                    {FilterType.HOUR, "Hora" },
                                    {FilterType.EVENT_TOPIC, "Tema" },
                                    {FilterType.EVENT_TYPE, "Tipo" },
                                    {FilterType.PRICE, "Precio" },
                                    {FilterType.WEEKEND, "Fin de semana" },
                                };
     
    }

    public static class DrawerStatesTypes
    {
        public const string Normal = "Normal";
        public const string Selected = "Selected";
        public const string WaitingForSelect = "WaitingForSelect";
        public const string Marked = "Marked";
    }
    public static class ClearOptions
    {
        public const string All = "All";
        public const string SelectedDates = "SelectedDates";
        public const string SelectedHours = "SelectedHours";
        public const string SelectedPrices = "SelectedPrices";

    }
}
