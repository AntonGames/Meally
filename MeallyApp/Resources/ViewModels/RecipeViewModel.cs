using CommunityToolkit.Mvvm.Input;
using MeallyApp.Resources.ExceptionHandling;
using MeallyApp.Resources.Ingredients;
using MeallyApp.Resources.Services;
using System.Collections.ObjectModel;

namespace MeallyApp.Resources.ViewIngredients
{
    public partial class RecipeViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; } = new();

        private IExceptionLogger logger;
        private IRecipeHandler recipeHandler;

        public Command GetRecipesCommand { get; }

        public RecipeViewModel(IExceptionLogger logger, IRecipeHandler recipeHandler)
        {
            Title = "Recipes";
            this.logger = logger;
            this.recipeHandler = recipeHandler;
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
                var recipes = recipeHandler.GetRecipeList();

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
                logger.WriteToLog("Unable to display recipes.");
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
