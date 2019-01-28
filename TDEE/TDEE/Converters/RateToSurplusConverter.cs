using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TDEE.Converters
{
    public class RateToSurplusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MyDouble.TryParse((string)value, out double a) ? (a * UserSettings.CaloriesPerUnit / 7.0).ToString() : (string)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MyDouble.TryParse((string)value, out double a) ? (a * 7.0 / UserSettings.CaloriesPerUnit).ToString() : (string)value;
        }
    }
}
