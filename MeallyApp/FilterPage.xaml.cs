using MeallyApp.UserData;
using MeallyApp.Resources.Services;
using MeallyApp.Resources.ViewIngredients;

namespace MeallyApp;

public partial class FilterPage : ContentPage
{
    public RecipeViewModel ViewModel { get; }

    public FilterPage(RecipeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        ViewModel = viewModel;
    }

    private async void RecipeButton_OnClicked(object sender, EventArgs e)
    {
        if (!Loader.IsRunning)
        {
            Loader.IsRunning = true;
            await RecipeHandler.GetDBAsync();
            RecipeHandler.SetComp(User.inventory);
            RecipeHandler.OrderDB();
            Loader.IsRunning = false;
            ViewModel.GetRecipesCommand.Execute(this);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.GetRecipesCommand.Execute(this);
    }
}