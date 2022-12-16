using MeallyApp.Resources.Ingredients;
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

            string url = "https://localhost:44393/api/food/getingredients";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respone = await client.GetAsync("");
            if(respone.IsSuccessStatusCode)
            {
                string content = respone.Content.ReadAsStringAsync().Result;
                ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(content);

                foreach (Ingredient A in ingredientList)
                {

                    Debug.WriteLine($"\n{A.DisplayName}\n");

                }

                return ingredientList;
            }

            return null;
        }
    }
}
