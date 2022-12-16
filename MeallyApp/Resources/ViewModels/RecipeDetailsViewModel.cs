using CommunityToolkit.Mvvm.ComponentModel;
using MeallyApp.Resources.Ingredients;

namespace MeallyApp.Resources.ViewIngredients
{
	[QueryProperty(nameof(Recipe), nameof(Recipe))]
	public partial class RecipeDetailsViewModel : ObservableObject
	{
        [ObservableProperty]
        Recipe recipe;

		[ObservableProperty]
		List<Ingredient> ingredients;

        public RecipeDetailsViewModel()
		{
			// Add "GET ingredients ?recipe" request


		}
	}
}