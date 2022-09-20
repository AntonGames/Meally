using Java.Security;
using System.Collections.ObjectModel;

namespace MeallyApp;

public partial class MainPage : ContentPage
{
    private string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ingredients.txt");

    private ObservableCollection<String> Products = new ObservableCollection<string>();
 
    public MainPage()
    {
        //Products = ProductManager.GetProducts();
        InitializeComponent();
    }

    public void ClearEntryText(Entry EntryObj)
    {
        Console.WriteLine("Text Cleared!");
        EntryObj.Text = "";
    }

    private void AddButton_OnClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(IngEntry.Text))
        {
            File.AppendAllText(_fileName, IngEntry.Text + Environment.NewLine);
        }
        ClearEntryText(IngEntry);
    }

    private void LoadButton_OnClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName)) 
        {
            string[] buffer = File.ReadAllLines(_fileName);
            foreach(string line in buffer)
            {
                Console.WriteLine(line);
                Products.Add(line);
            }
            lvProduct.ItemsSource = Products;
        }
    }

    private void DeleteButton_OnClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }

        IngEntry.Text = string.Empty;
    }
}

