using RecipeDatabaseDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDatabaseDomain.ViewModels
{
    public class RecipeViewModel
    {
        public string? Name { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        public string? RecipeInstructions { get; set; }

        public string? Image { get; set; }

        public RecipeViewModel(string name, List<Ingredient> ingredients, string recipeInstructions, string recipeImage = "place_holder.png")
        {
            Name = name;
            Ingredients = ingredients;
            RecipeInstructions = recipeInstructions;
            Image = recipeImage;
        }
    }
}
