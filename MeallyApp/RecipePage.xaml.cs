using MeallyApp.Resources.ViewIngredients;
using Newtonsoft.Json;
using MeallyApp.UserData;
using MeallyApp.Resources.Ingredients;
using System.Diagnostics;

namespace MeallyApp;

public partial class RecipePage : ContentPage
{
    public RecipeDetailsViewModel vm = new RecipeDetailsViewModel();

	public RecipePage()
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async Task<List<Ingredient>> GetRecipeIngredients(int id)
    {
        // Get ingredients based on recipe ID (If just casting to a list wouldnt work)
        var client = new HttpClient();
        List<Ingredient> temp = new();
        string url = $"{User.BaseUrl}/api/food/getrecipe/{id}";
        client.BaseAddress = new Uri(url);
        HttpResponseMessage respone = await client.GetAsync("");
        if (respone.IsSuccessStatusCode)
        {
            string content = respone.Content.ReadAsStringAsync().Result;
            temp = JsonConvert.DeserializeObject<List<Ingredient>>(content);
        }
        return temp;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        /*
        Task<List<Ingredient>> task = Task.Run(() => GetRecipeIngredients(vm.Recipe.Id));

        vm.Ingredients = task.Result;
        */

        vm.Ingredients = vm.Recipe.Ingredients as List<Ingredient>;
    }

}