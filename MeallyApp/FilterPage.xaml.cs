using MeallyApp.UserData;
using MeallyApp.Resources;
using MeallyApp.Resources.Services;
using MeallyApp.Resources.ViewIngredients;
using MeallyApp.Resources.ExceptionHandling;
using Microsoft.Maui.Controls.Shapes;

namespace MeallyApp;

public delegate void ExceptionDelegate();

public partial class FilterPage : ContentPage
{
    public RecipeViewModel ViewModel { get; }

    // 4. Delegate usage

    private ExceptionDelegate action; 

    public FilterPage(RecipeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        ViewModel = viewModel;
        ExceptionLogger.exceptionAddedToFile += Logger_OnException;  // added event handler method to an event
        action = ExceptionLogger.ClearLog;
        action();
    }

    private void ExceptionLogButton_OnClicked(object sender, EventArgs e)
    {
        action = ExceptionLogger.ReadFromLog;
        action();
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

    private void Logger_OnException(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    }
}