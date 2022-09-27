using MeallyApp.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Services
{
    public class IngredientService
    {
        private List<Ingredient> ingredientList = new ();

        public IngredientService()
        {
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Spaghetti, "Spaghetti", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Butter, "Butter", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Cheese, "Cheese", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Pepper, "Pepper", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.CasterSugar, "Caster sugar", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Flour, "Flour", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Eggs, "Eggs", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Lemon, "Lemon", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.VanillaEssence, "Vanilla essence", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.LemonCurd, "Lemon curd", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.OliveOil, "Olive oil", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Bacon, "Bacon", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Onion, "Onion", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Celery, "Celery", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Carrot, "Carrot", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Beef, "Beef", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Tomatoes, "Tomatoes", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Honey, "Honey", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.LasagneSheets, "Lasagne sheets", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Mozzarella, "Mozzarella", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Parmesan, "Parmesan", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.CremeFraiche, "Crème fraîche", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Milk, "Milk", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Salt, "Salt", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Cucumber, " Cucumber", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Coriander, "Coriander", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Potatoes, "Potatoes", "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Paprika, "Paprika", "IMG"));
        }

        public async Task<List<Ingredient>> GetIngredients()
        {
            if(ingredientList?.Count > 0)
            {
                return ingredientList;
            }
            else
            {
                return null;
            }
        }
    }
}
