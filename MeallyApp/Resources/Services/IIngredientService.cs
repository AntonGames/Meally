using MeallyApp.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Services
{
    public interface IIngredientService
    {
        public Task<List<Ingredient>> GetIngredients();
    }
}
