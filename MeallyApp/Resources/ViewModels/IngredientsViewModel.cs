using MeallyApp.Resources.ExceptionHandling;
using MeallyApp.Resources.Ingredients;
using MeallyApp.Resources.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;


namespace MeallyApp.Resources.ViewIngredients
{
    public partial class IngredientsViewModel : BaseViewModel
    {
        IIngredientService ingredientService;

        public ObservableCollection<Ingredient> IngredientsCollection { get; } = new();

        private IExceptionLogger logger;

        public Command GetIngredientsCommand { get; }

        public IngredientsViewModel(IIngredientService ingredientService, IExceptionLogger logger)
        {
            Title = "Ingredient Picker";
            this.ingredientService = ingredientService;
            this.logger = logger;
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
                var ingredients = ingredientService.GetIngredients();

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
                logger.WriteToLog("Unable to display products.");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    
}
