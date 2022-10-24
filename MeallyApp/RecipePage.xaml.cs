using MeallyApp.Resources.ViewIngredients;

namespace MeallyApp;

public partial class RecipePage : ContentPage
{
	public RecipePage(RecipeDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}