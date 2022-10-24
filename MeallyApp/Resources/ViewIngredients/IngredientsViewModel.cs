using MeallyApp.Resources.Ingredients;
using MeallyApp.Resources.Services;
using System.Collections.ObjectModel;


namespace MeallyApp.Resources.ViewIngredients
{
    public partial class IngredientsViewModel : BaseViewModel
    {
        IngredientService ingredientService;

        public ObservableCollection<Ingredient> IngredientsCollection { get; } = new();

        public Command GetIngredientsCommand { get; }

        public IngredientsViewModel(IngredientService ingredientService)
        {
            Title = "Ingredient Picker";
            this.ingredientService = ingredientService;
            GetIngredientsCommand = new Command(async () => await GetIngredientAsync());
            GetIngredientsCommand.Execute(this);
        }


        async Task GetIngredientAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var ingredients = await ingredientService.GetIngredients();

                if (IngredientsCollection.Count != 0)
                {
                    IngredientsCollection.Clear();
                }

                foreach(var ingredient in ingredients)
                {
                    IngredientsCollection.Add(ingredient);
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error!", "Unable to display products.", "OK!");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    
}
