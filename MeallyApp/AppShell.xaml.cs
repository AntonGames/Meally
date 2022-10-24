namespace MeallyApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
	}
}
