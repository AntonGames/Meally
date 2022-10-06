namespace MeallyApp.Resources.Ingredients
{
    public class Ingredient
    {
        public Ingredient() {;}

        public Ingredient(Ingredients ingredient, string image)
        {
            this.ingredient = ingredient;
            Image = image;
        }

        public Ingredients ingredient { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return ingredient.ToString();
        }

    }
}
