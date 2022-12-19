using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Converters
{
    class IngredientToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Ingredient temp = value as Ingredient;
            
            if(temp != null && !User.inventory.Contains(temp))
            {
                return Colors.Red;
            }

            return Colors.Black;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
