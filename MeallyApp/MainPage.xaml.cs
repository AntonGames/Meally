using MeallyApp.Resources.ViewIngredients;
using MeallyApp.Resources.Ingredients;
using MeallyApp.UserData;
using MeallyApp.Resources.Services;
using Flurl.Http;
using System.Diagnostics;

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
    private async void AddButton_OnClicked(object sender, EventArgs e)
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
            try
            {
                var result = await $"{User.BaseUrl}/api/user/updateinventory".PostJsonAsync(new
                {
                    Username = User.UserName,
                    Ingredients = new List<Ingredient>(User.inventory)
                });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            //result RETURNS StatusCode.200K if everything ok and StatusCode.404 if somtehing went wrong.
        }

    }
}

