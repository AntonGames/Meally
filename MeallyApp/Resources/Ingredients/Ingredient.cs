using System.Text.RegularExpressions;

namespace MeallyApp.Resources.Ingredients
{
    public class Ingredient
    {
        public Ingredient() {;}

        public Ingredient(string DisplayName, string image)
        {
            this.DisplayName = DisplayName;
            this.Image = image;
        }

        public string DisplayName { get; set; } 

        public string Image { get; set; }

        // Regex usage
        public override string ToString()
        {
            return DisplayName;
        }

    }
}
