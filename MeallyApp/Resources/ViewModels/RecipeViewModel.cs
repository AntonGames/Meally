using CommunityToolkit.Mvvm.Input;
using MeallyApp.Resources.Ingredients;
using MeallyApp.Resources.Services;
using System.Collections.ObjectModel;

namespace MeallyApp.Resources.ViewIngredients
{
    public partial class RecipeViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; } = new();



        public Command GetRecipesCommand { get; }

        public RecipeViewModel()
        {
            Title = "Recipes";
            GetRecipesCommand = new Command(async () => await GetRecipesAsync());
        }

        async Task GetRecipesAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var recipes = RecipeHandler.GetRecipeList();

                if (Recipes.Count != 0)
                {
                    Recipes.Clear();
                }

                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error!", "Unable to display products.", "OK!");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task Tap(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}",true , new Dictionary<string, object> { ["Recipe"] = recipe });
        }
        
    }
}
