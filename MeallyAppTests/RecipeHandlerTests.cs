using MeallyApp.Resources.ExceptionHandling;
using MeallyApp.Resources.Ingredients;
using MeallyApp.Resources.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MeallyAppTests
{
    public class RecipeHandlerTests
    {
        public MeallyApp.Resources.ExceptionHandling.IExceptionLogger logger;

        public IDatabaseConnection databaseConnection;

        public RecipeHandler recipeHandler;

        private string[] recipeNamesArray = { 
            "Tomato, cucumber and coriander salad",
            "Lemon pudding",
            "Cacio e pepe",
            "Roast beef",
            "Scrambled eggs",
            "Lasagna",
            "Spanish potatoes"
        };

        public RecipeHandlerTests()
        {
            logger = new ExceptionLogger();
            databaseConnection = new DatabaseConnection(logger);
            recipeHandler = new RecipeHandler(databaseConnection);
        }

        [Test, Order(1)]
        public async Task GetRecipesTest()
        {
            await recipeHandler.GetRecipesFromDB();
            Assert.AreNotEqual(recipeHandler.GetRecipeList().Count, 0);
        }

        [Test, Order(2)]
        public void TestOrderDB()
        {
            recipeHandler.OrderDB();
            List<Recipe> actualList = recipeHandler.GetRecipeList();

            for(int i = 0; i < actualList.Count; i++)
            {
                Assert.AreEqual(recipeNamesArray[i], actualList[i].Name);
            }
        }
    }
}
