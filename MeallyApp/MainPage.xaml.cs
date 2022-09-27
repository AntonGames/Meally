using MeallyApp.Resources.ViewIngredients;
using System.Collections.ObjectModel;

namespace MeallyApp;

public partial class MainPage : ContentPage
{
    private string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ingredients.txt");
 
    public MainPage(IngredientsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public void ClearEntryText(Entry EntryObj)
    {
        Console.WriteLine("Text Cleared!");
        EntryObj.Text = "";
    }

    private void AddButton_OnClicked(object sender, EventArgs e)
    {
       
    }

    private void LoadButton_OnClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName)) 
        {
            string[] buffer = File.ReadAllLines(_fileName);
            foreach(string line in buffer)
            {
                Console.WriteLine(line);
            }
        }
    }

    private void DeleteButton_OnClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
    }
}

