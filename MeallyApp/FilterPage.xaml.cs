using MeallyApp.UserData;
using MeallyApp.Resources;
using MeallyApp.Resources.Services;
using MeallyApp.Resources.ViewIngredients;
using MeallyApp.Resources.ExceptionHandling;
using Microsoft.Maui.Controls.Shapes;
using MeallyApp.Resources.EventArguments;

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

        //Subscribing to custom event
        ExceptionLogger.exceptionAddedToFile += delegate (string message)  // added event handler method to a custom event
        {
            System.Diagnostics.Debug.WriteLine(message);
        };

        //Subscribing to standart event
        RecipeHandler.RecipesLoaded += delegate (object sender, RecipesLoadedEventArgs arguments)  // added even handler method to a standart event
        {
            System.Diagnostics.Debug.WriteLine("Standart event:  " + arguments.message);
        };
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
}