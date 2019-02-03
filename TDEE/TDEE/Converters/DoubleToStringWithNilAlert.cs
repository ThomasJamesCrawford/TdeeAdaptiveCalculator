using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TDEE.Converters
{
    public class DoubleToStringWithNilAlert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value == -1 ? "Nil" : value; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;

            if (MyDouble.TryParse(s, out double d))
            {
                return d;
            }
            else
            {
                return value;
            }
        }
    }
}
