using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Ingredients
{
    public class Recipe
    {
        public string Name { get; }

        public List<Ingredient> Ingredients;
        public string RecipeInstructions { get; }

        public string Image;

        public double Compatibility = 0;

        public Recipe(string name, List<Ingredient> ingredients, string recipeInstructions)
        {
            Name = name;
            this.Ingredients = ingredients;
            RecipeInstructions = recipeInstructions;
        }
    }
}
