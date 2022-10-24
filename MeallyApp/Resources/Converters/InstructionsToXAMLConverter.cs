using Android.Text.Method;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Converters
{
    internal class InstructionsToXAMLConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            //replace \n and \r as &#x0a;

            value = value.ToString().Replace("\r\n", Environment.NewLine);
            value = value.ToString().Replace("\n", Environment.NewLine);
            value = value.ToString().Replace("\r", Environment.NewLine);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
