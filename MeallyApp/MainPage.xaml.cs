namespace MeallyApp;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }



    public void clearEntryText(Entry EntryObj)
    {
        Console.WriteLine("Text Cleared!");
        EntryObj.Text = "";
        

    }

    private void AddButton_OnClicked(object sender, EventArgs e)
    {
        clearEntryText(IngEntry);
    }

    private void LoadButton_OnClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}

