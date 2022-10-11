using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Ingredients
{
    public class Recipe
    {
        public string Name { get; set; }

        public List<Ingredient> Ingredients;
        public string RecipeInstructions { get; set; }

        public string Image { get; set;}

        public double Compatibility { get; set; } = 0;

        public Recipe(string name, List<Ingredient> ingredients, string recipeInstructions)
        {
            Name = name;
            this.Ingredients = ingredients;
            RecipeInstructions = recipeInstructions;
        }
    }
}
