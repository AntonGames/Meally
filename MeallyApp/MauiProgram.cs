using MeallyApp.Resources.Services;
using MeallyApp.Resources.ViewIngredients;

namespace MeallyApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IngredientService>();

		builder.Services.AddSingleton<IngredientsViewModel>();

		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<RecipeViewModel>();

        builder.Services.AddSingleton<FilterPage>();

        return builder.Build();
	}
}
