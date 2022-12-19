using RecipeDatabaseDomain.Models;
using RecipeDatabaseDomain.ViewModels;

namespace MeallyDBapi.Infrastructure
{
    public interface IMeallyDataRepository
    {
        public List<Ingredient> GetAllIngredients();

        public List<RecipeViewModel> GetAllRecipes();

        public void RegisterUser(UserAccount userAccount);


        public bool VerifyData(UserAccount userAccount, out string message);

        public List<Ingredient>? VerifyUser(string username, string password);

        public void DeleteUserIngredients(string username);

        public bool UpdateUserInventory(UserIngredientsRequest request);

        public List<Ingredient> GetRecipe(int id);


    }
}
