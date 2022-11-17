using MeallyApp.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Services
{
    public interface IRecipeHandler
    {
        public Task GetRecipesFromDB();
        public void SetComp(List<Ingredient> userIngredients);
        public void OrderDB();
        public void PrintDB();
        public List<Recipe> GetRecipeList();
    }
}
