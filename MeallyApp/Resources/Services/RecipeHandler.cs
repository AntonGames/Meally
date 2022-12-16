using MeallyApp.Resources.EventArguments;
using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using Newtonsoft.Json;
using Npgsql;

namespace MeallyApp.Resources.Services
{
    public class RecipeHandler : IRecipeHandler
    {
        // This is a list of all recipes

        private List<Recipe> database = new List<Recipe>();

        public IDatabaseConnection dbConnection;

        public RecipeHandler(IDatabaseConnection databaseConnection)
        {
            dbConnection = databaseConnection;
        }

        public async Task GetRecipesFromDB()
        {
            await dbConnection.GetDBAsync();
            database = dbConnection.GetRecipeList();
        }

        public async Task GetRecipesAPI()
        {
            var client = new HttpClient();

            string url = "https://localhost:44393/api/food/getrecipes";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respone = await client.GetAsync("");
            if (respone.IsSuccessStatusCode)
            {
                string content = respone.Content.ReadAsStringAsync().Result;
                database = JsonConvert.DeserializeObject<List<Recipe>>(content);
            }
        }

        // Set Compatibility rating on Recipe list
        public void SetComp(List<Ingredient> userIngredients)
        {

            foreach (var recipe in database)
            {
                var missingIngredients = recipe.Ingredients.Where(a => !User.inventory.Exists(b => b.DisplayName.Equals(a.DisplayName))).ToList();

                double recipeCount = recipe.Ingredients.Count;
                double missingCount = missingIngredients.Count;

                recipe.Compatibility = Math.Round((recipeCount - missingCount) / recipeCount,2);
            }

        }

        // Order list of recipes by compatibility
        // LINQ to Objects usage (methods and queries)
        public void OrderDB()
        {
            List<Recipe> tempList = database.OrderByDescending(x => x.Compatibility).ToList();
            for (int i = 0; i < database.Count; i++)
            {
                database[i] = tempList[i];
            }
        }

        // Print all recipes in database
        public void PrintDB()
        {
            foreach (var recipe in database)
            {
                Console.WriteLine($"[Name: {recipe.Name}] [Compatibility: {recipe.Compatibility}]\n");
                recipe.Ingredients.ForEach(i => Console.Write("{0}\t", i));
                Console.WriteLine("\n\n");
            }
        }

        public List<Recipe> GetRecipeList()
        {
            return new List<Recipe>(database);
        }

    }

}
