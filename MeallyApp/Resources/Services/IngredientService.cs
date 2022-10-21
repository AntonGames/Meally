using MeallyApp.Resources.Ingredients;

namespace MeallyApp.Resources.Services
{
    public class IngredientService
    {
        private List<Ingredient> ingredientList = new ();

        public IngredientService()
        {
            // named argument usage
            ingredientList.Add(new Ingredient(image: "IMG", ingredient: Ingredients.Ingredients.Spaghetti));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Butter, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Garlic, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Cheese, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Pepper, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.CasterSugar, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Flour, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Eggs, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Lemon,"IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.VanillaEssence, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.LemonCurd, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.OliveOil, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Bacon, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Onion, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Celery,"IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Carrot, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Beef, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Tomatoes, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Honey, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.LasagneSheets, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Mozzarella,"IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Parmesan, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.CremeFraiche, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Milk, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Salt, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Cucumber, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Coriander, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Potatoes, "IMG"));
            ingredientList.Add(new Ingredient(Ingredients.Ingredients.Paprika, "IMG"));
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
