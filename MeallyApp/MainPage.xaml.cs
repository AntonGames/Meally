using MeallyApp.Resources.ViewIngredients;
using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using MeallyApp.Resources.Services;

namespace MeallyApp;

public partial class MainPage : ContentPage
{
    private List<Ingredient> selection = new List<Ingredient>();

    private IRecipeHandler recipeHandler;

    public MainPage(IngredientsViewModel viewModel, IRecipeHandler recipeHandler)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.recipeHandler = recipeHandler;
    }
    private void AddButton_OnClicked(object sender, EventArgs e)
    {
        selection.Clear();

        if (IngridientView.SelectedItems != null)
        {
            // CollectionView returns IList<object>, code below casts IList<object> to List<Ingredients>
            object tempObject;

            foreach (var o in IngridientView.SelectedItems)
            {
                tempObject = o;
                // Widening and narrowing type conversions
                selection.Add(tempObject as Ingredient);
            }

            // Assign inventory and clear selection
            User.inventory = selection;
            recipeHandler.SetComp(User.inventory);
            recipeHandler.OrderDB();
            IngridientView.SelectedItems.Clear();

            // Add request for sending inventory to API
        }
    }
}

