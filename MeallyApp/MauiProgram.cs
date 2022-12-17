using CommunityToolkit.Maui;
using MeallyApp.Resources.ExceptionHandling;
using MeallyApp.Resources.Services;
using MeallyApp.Resources.ViewIngredients;
using MeallyApp.Resources.ViewModels;

namespace MeallyApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<LoginPage>();

        builder.Services.AddSingleton<LoginPageViewModel>();

        builder.Services.AddSingleton<IIngredientService, IngredientService>();

		builder.Services.AddSingleton<IngredientsViewModel>();

		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<RecipeViewModel>();

        builder.Services.AddSingleton<FilterPage>();

        builder.Services.AddTransient<RecipeDetailsViewModel>();

        builder.Services.AddTransient<RecipePage>();

		builder.Services.AddSingleton<IExceptionLogger, ExceptionLogger>();

		builder.Services.AddSingleton<IRecipeHandler, RecipeHandler>();

		builder.Services.AddSingleton<IDatabaseConnection, DatabaseConnection>();

        return builder.Build();
	}
}
