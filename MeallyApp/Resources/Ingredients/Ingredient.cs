using System.Text.RegularExpressions;

namespace MeallyApp.Resources.Ingredients
{
    public class Ingredient
    {
        public Ingredient() {;}

        public Ingredient(Ingredients ingredient, string image)
        {
            this.ingredient = ingredient;
            displayName = this.ToString();
            this.Image = image;
        }

        public Ingredients ingredient { get; set; }

        public string displayName { get; set; } 

        public string Image { get; set; }

        // Regex usage
        public override string ToString()
        {
            return Regex.Replace(ingredient.ToString(), "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
        }

    }
}
