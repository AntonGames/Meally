using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MeallyApp.Resources.Services
{
    public class IngredientService : IIngredientService
    {
        private List<Ingredient> ingredientList = new ();

        public IngredientService()
        {

        }

        public List<Ingredient> GetIngredientsList()
        {
            ingredientList.Add(new Ingredient("Paprika", "IMG"));
            return ingredientList;
        }

        public async Task<List<Ingredient>> GetIngredients()
        {
            var client = new HttpClient();

            string url = $"{User.BaseUrl}/api/food/getingredients";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respone = await client.GetAsync("");
            if(respone.IsSuccessStatusCode)
            {
                string content = respone.Content.ReadAsStringAsync().Result;
                ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(content);
                return ingredientList;
            }

            return null;
        }
    }
}
