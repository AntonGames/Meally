using MeallyApp.UserData;
using MeallyApp.Resources.Services;

namespace MeallyApp;

public partial class FilterPage : ContentPage
{
	public FilterPage()
	{
		InitializeComponent();
	}

	private async void RecipeButton_OnClicked(object sender, EventArgs e)
    {
        var file = await FilePicker.PickAsync(new PickOptions());

        if (file != null)
        {
            if(file.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase)) 
            RecipeHandler.DBPath = file.FullPath;
            RecipeHandler.GetDB();
            RecipeHandler.SetComp(User.inventory);
            RecipeHandler.OrderDB();
            RecipeHandler.PrintDB();
        }
        else
        {
            return;
        }
    }
}