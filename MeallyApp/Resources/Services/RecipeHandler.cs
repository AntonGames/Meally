using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using Npgsql;

namespace MeallyApp.Resources.Services
{
    public static class RecipeHandler
    {
        // This is a list of all recipes
        // Generic

        private static Lazy<List<Recipe>> database = new Lazy<List<Recipe>>();

        // Get recipes from database
        public static async Task GetDBAsync()
        {
            RecipeHandler.database.Value.Clear();
         
            // Setup bit.io database connection
            var bitHost = "db.bit.io";
            var bitUser = "";
            var bitDbName = "LorryGailius/Meally";
            var bitApiKey = "v2_3usyy_JDfAYxxp5xTy6SgPPGEiZF4";

            var cs = $"Host={bitHost};Username={bitUser};Password={bitApiKey};Database={bitDbName}";

            using var con = new NpgsqlConnection(cs);

            await con.OpenAsync();
            con.TypeMapper.UseJsonNet();
            using (var cmd = new NpgsqlCommand(@"SELECT json_build_object('Name', Name, 'Image', Image, 'Compatibility', Compatibility, 'RecipeInstructions', RecipeInstructions, 'Ingredients', Ingredients) FROM ""Recipes"";", con))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var temp = reader.GetFieldValue<Recipe>(0);
                    database.Value.Add(temp);
                }
            }
            con.Close();
        }

        // Set Compatibility rating on Recipe list
        public static void SetComp(List<Ingredient> userIngredients)
        {
            foreach (var recipe in database.Value)
            {
                var missingIngredients = recipe.Ingredients.Where(a => !User.inventory.Exists(b => b.ingredient.Equals(a.ingredient))).ToList();

                double recipeCount = recipe.Ingredients.Count;
                double missingCount = missingIngredients.Count;

                recipe.Compatibility = Math.Round((recipeCount - missingCount) / recipeCount,2);
            }
        }

        // Order list of recipes by compatibility
        // LINQ to Objects usage (methods and queries)
        public static void OrderDB()
        {
            List<Recipe> tempList = database.Value.OrderByDescending(x => x.Compatibility).ToList();
            for (int i = 0; i < database.Value.Count; i++)
            {
                database.Value[i] = tempList[i];
            }
        }

        // Print all recipes in database
        public static void PrintDB()
        {
            foreach (var recipe in database.Value)
            {
                Console.WriteLine($"[Name: {recipe.Name}] [Compatibility: {recipe.Compatibility}]\n");
                recipe.Ingredients.ForEach(i => Console.Write("{0}\t", i));
                Console.WriteLine("\n\n");
            }
        }

        // 4. Extension method usage for recipe
        public static void PrintRecipe(this Recipe recipe)
        {
            Console.WriteLine($"[Name: {recipe.Name}] [Compatibility: {recipe.Compatibility}]\n");
            recipe.Ingredients.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("\n\n");
        }

        public static List<Recipe> GetRecipeList()
        {
            return new List<Recipe>(database.Value);
        }

    }

}
