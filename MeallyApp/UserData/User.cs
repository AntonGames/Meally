using MeallyApp.Resources.Ingredients;

namespace MeallyApp.UserData
{
    public static class User
    {
        public static List<Ingredient> inventory = new List<Ingredient>();

        public static void PrintInv()
        {
            foreach (var ing in inventory)
            {
                Console.WriteLine(ing.ingredient.ToString());
            }
        }

        //Add ingridients to inventory (for testing purposes only)
        public static void AddInv()
        {
            inventory.Add(new Ingredient(Ingredients.Spaghetti, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Butter, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Garlic, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Cheese, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Pepper, "IMG"));
            inventory.Add(new Ingredient(Ingredients.CasterSugar, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Flour, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Eggs, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Lemon, "IMG"));
            inventory.Add(new Ingredient(Ingredients.VanillaEssence, "IMG"));
            inventory.Add(new Ingredient(Ingredients.LemonCurd, "IMG"));
            inventory.Add(new Ingredient(Ingredients.OliveOil, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Bacon, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Onion, "IMG"));
            inventory.Add(new Ingredient(Ingredients.Celery, "IMG"));
        }


    }
}
