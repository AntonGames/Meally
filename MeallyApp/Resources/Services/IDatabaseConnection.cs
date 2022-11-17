using MeallyApp.Resources.EventArguments;
using MeallyApp.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Services
{
    public interface IDatabaseConnection
    {
        public Task GetDBAsync();
        public List<Recipe> GetRecipeList();

        public event EventHandler<RecipesLoadedEventArgs> RecipesLoaded;
    }
}
