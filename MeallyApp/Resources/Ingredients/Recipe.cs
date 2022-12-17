namespace MeallyApp.Resources.Ingredients
{
    public class Recipe : IComparable<Recipe>
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public string RecipeInstructions { get; set; }

        public string Image { get; set;}

        public double Compatibility { get; set; } = 0;

        public Recipe(string name, List<Ingredient> ingredients, string recipeInstructions, string recipeImage = "place_holder.png")
        {
            Name = name;
            this.Ingredients = ingredients;
            RecipeInstructions = recipeInstructions;
        }

        // 10. IComparable interface 
        public int CompareTo(Recipe other)
        {
            if (this.Compatibility > other.Compatibility)
            {
                return -1;
            }
            else if (this.Compatibility < other.Compatibility)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
