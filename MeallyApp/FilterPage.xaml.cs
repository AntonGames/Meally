namespace MeallyApp;

public partial class FilterPage : ContentPage
{
	public FilterPage()
	{
		InitializeComponent();
	}

	private async void RecipeButton_OnClicked(object sender, EventArgs e)
    {
        try
        {
            var file = await FilePicker.PickAsync(new PickOptions());
            
            if (file == null)
            {
                return;
            }

            TempText.Text = file.FullPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("User cancelled file pick");
            throw;
        }
    }
}