using MeallyApp.Resources.ViewIngredients;
using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;

namespace MeallyApp;

public partial class MainPage : ContentPage
{
    private List<Ingredient> selection = new List<Ingredient>();

    public MainPage(IngredientsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    private void AddButton_OnClicked(object sender, EventArgs e)
    {
        selection.Clear();

        if (IngridientView.SelectedItems != null)
        {
            // CollectionView returns IList<object>, code below casts IList<object> to List<Ingredients>
            object tempObject = new Ingredient();

            foreach (var o in IngridientView.SelectedItems)
            {
                tempObject = o;
                // Widening and narrowing type conversions
                selection.Add(tempObject as Ingredient);
            }

            // Assign inventory and clear selection
            User.inventory = selection;
            IngridientView.SelectedItems.Clear();

            /*
            // Used for individual item selection casting
            // Change IngridientView.SelectedItems to IngridientView.SelectedItem
            object o = new Ingredient();
            o = (IngridientView.SelectedItem); 
            Ingredient selection = o as Ingredient;
            Console.WriteLine("Selected item is {0}", selection.Name);
            */
        }
    }
}

