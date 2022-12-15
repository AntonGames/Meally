using MeallyApp.Resources.Ingredients;

namespace MeallyApp.Resources.Services
{
    public class IngredientService : IIngredientService
    {
        private List<Ingredient> ingredientList = new ();

        public IngredientService()
        {
            ingredientList.Add(new Ingredient("Paprika", "IMG"));
        }

        public List<Ingredient> GetIngredients()
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
