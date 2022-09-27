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
        
        private List<Ingredient> ingredients;

        public List<Ingredient> Ingredients { get { return ingredients; } } 

        public string RecipeInstructions { get; }

        public Recipe(string name, List<Ingredient> ingredients, string recipeInstructions)
        {
            Name = name;
            this.ingredients = ingredients;
            RecipeInstructions = recipeInstructions;
        }
    }
}
