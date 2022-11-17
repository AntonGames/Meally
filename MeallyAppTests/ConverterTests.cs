using MeallyApp.Resources.Converters;
using MeallyApp.Resources.Ingredients;
using System.Collections.ObjectModel;

namespace MeallyAppTests
{
    public class ConverterTests
    {
        Recipe[] recipes = new Recipe[]
        {
                new Recipe ("Pie", new List<Ingredient>(), "Something", "IMG.png"),
                new Recipe ("Bread", new List<Ingredient>(), "Something", "IMG.png"),
                new Recipe ("Salad", new List<Ingredient>(), "Something", "IMG.png"),
                new Recipe ("Soup", new List<Ingredient>(), "Something", "IMG.png")
        };

        List<Recipe> recipesList = new List<Recipe>
        {
                new Recipe ("Pie", new List<Ingredient>(), "Something", "IMG.png"),
                new Recipe ("Bread", new List<Ingredient>(), "Something", "IMG.png"),
                new Recipe ("Salad", new List<Ingredient>(), "Something", "IMG.png"),
                new Recipe ("Soup", new List<Ingredient>(), "Something", "IMG.png")
        };

        public ConverterTests()
        {
            recipes[0].Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));
            recipes[0].Ingredients.Add(new Ingredient(Ingredients.Flour, "IMG"));
            recipes[0].Ingredients.Add(new Ingredient(Ingredients.Eggs, "IMG"));
            recipes[0].Ingredients.Add(new Ingredient(Ingredients.Lemon, "IMG"));

            recipes[1].Ingredients.Add(new Ingredient(Ingredients.Flour, "IMG"));
            recipes[1].Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));

            recipes[2].Ingredients.Add(new Ingredient(Ingredients.Celery, "IMG"));
            recipes[2].Ingredients.Add(new Ingredient(Ingredients.Carrot, "IMG"));
            recipes[2].Ingredients.Add(new Ingredient(Ingredients.Tomatoes, "IMG"));

            recipes[3].Ingredients.Add(new Ingredient(Ingredients.Tomatoes, "IMG"));
            recipes[3].Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));
            recipes[3].Ingredients.Add(new Ingredient(Ingredients.Beef, "IMG"));

            recipesList[0].Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));
            recipesList[0].Ingredients.Add(new Ingredient(Ingredients.Flour, "IMG"));
            recipesList[0].Ingredients.Add(new Ingredient(Ingredients.Eggs, "IMG"));
            recipesList[0].Ingredients.Add(new Ingredient(Ingredients.Lemon, "IMG"));

            recipesList[1].Ingredients.Add(new Ingredient(Ingredients.Flour, "IMG"));
            recipesList[1].Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));

            recipesList[2].Ingredients.Add(new Ingredient(Ingredients.Celery, "IMG"));
            recipesList[2].Ingredients.Add(new Ingredient(Ingredients.Carrot, "IMG"));
            recipesList[2].Ingredients.Add(new Ingredient(Ingredients.Tomatoes, "IMG"));

            recipesList[3].Ingredients.Add(new Ingredient(Ingredients.Tomatoes, "IMG"));
            recipesList[3].Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));
            recipesList[3].Ingredients.Add(new Ingredient(Ingredients.Beef, "IMG"));
        }

        [Test]
        public void ConvertToObservableCollectionTestArray()
        {
            ObservableCollection<Recipe> resultCollection = IEnumerableHelpers.ConvertToObservableCollection<Recipe>(recipes);

            Assert.AreEqual(recipes.Length, resultCollection.Count);

            Assert.AreEqual(recipes[0].Name, resultCollection[0].Name);
            Assert.AreEqual(recipes[1].Name, resultCollection[1].Name);
            Assert.AreEqual(recipes[2].Name, resultCollection[2].Name);
            Assert.AreEqual(recipes[3].Name, resultCollection[3].Name);


            for (int i = 0; i < recipes.Length; i++)
            {
                Assert.AreEqual(recipes[i].Name, resultCollection[i].Name);
                Assert.AreEqual(recipes[i].Ingredients.Count, resultCollection[i].Ingredients.Count);
                
                for (int j = 0; j < recipes[i].Ingredients.Count; j++)
                {
                    Assert.AreEqual(recipes[i].Ingredients[j].ingredient, resultCollection[i].Ingredients[j].ingredient);
                }
            }
        }

        [Test]
        public void ConvertToObservableCollectionTestList()
        {
            ObservableCollection<Recipe> resultCollection = IEnumerableHelpers.ConvertToObservableCollection<Recipe>(recipesList);

            Assert.AreEqual(recipesList.Count, resultCollection.Count);

            Assert.AreEqual(recipesList[0].Name, resultCollection[0].Name);
            Assert.AreEqual(recipesList[1].Name, resultCollection[1].Name);
            Assert.AreEqual(recipesList[2].Name, resultCollection[2].Name);
            Assert.AreEqual(recipesList[3].Name, resultCollection[3].Name);


            for (int i = 0; i < recipesList.Count; i++)
            {
                Assert.AreEqual(recipesList[i].Name, resultCollection[i].Name);
                Assert.AreEqual(recipesList[i].Ingredients.Count, resultCollection[i].Ingredients.Count);

                for (int j = 0; j < recipesList[i].Ingredients.Count; j++)
                {
                    Assert.AreEqual(recipesList[i].Ingredients[j].ingredient, resultCollection[i].Ingredients[j].ingredient);
                }
            }
        }

        [Test]
        public void TestSwapArray()
        {
            Recipe[] resultCollection = IEnumerableHelpers.Swap(recipes, 0, 1).ToArray();

            Assert.AreEqual(recipes.Length, resultCollection.Length);

            Assert.AreEqual(recipes[0].Name, resultCollection[1].Name);
            Assert.AreEqual(recipes[1].Name, resultCollection[0].Name);
            Assert.AreEqual(recipes[2].Name, resultCollection[2].Name);
            Assert.AreEqual(recipes[3].Name, resultCollection[3].Name);

            Assert.AreEqual(recipes[0].Ingredients.Count, resultCollection[1].Ingredients.Count);
            Assert.AreEqual(recipes[1].Ingredients.Count, resultCollection[0].Ingredients.Count);

            Assert.AreEqual(recipes[0].Ingredients[0].ingredient, resultCollection[1].Ingredients[0].ingredient);
            Assert.AreEqual(recipes[0].Ingredients[1].ingredient, resultCollection[1].Ingredients[1].ingredient);
            Assert.AreEqual(recipes[0].Ingredients[2].ingredient, resultCollection[1].Ingredients[2].ingredient);
            Assert.AreEqual(recipes[0].Ingredients[3].ingredient, resultCollection[1].Ingredients[3].ingredient);

            Assert.AreEqual(recipes[1].Ingredients[0].ingredient, resultCollection[0].Ingredients[0].ingredient);
            Assert.AreEqual(recipes[1].Ingredients[1].ingredient, resultCollection[0].Ingredients[1].ingredient);
        }

        [Test]
        public void TestSwapList()
        {
            Recipe[] resultCollection = IEnumerableHelpers.Swap(recipesList, 0, 1).ToArray();

            Assert.AreEqual(recipes.Length, resultCollection.Length);

            Assert.AreEqual(recipes[0].Name, resultCollection[1].Name);
            Assert.AreEqual(recipes[1].Name, resultCollection[0].Name);
            Assert.AreEqual(recipes[2].Name, resultCollection[2].Name);
            Assert.AreEqual(recipes[3].Name, resultCollection[3].Name);

            Assert.AreEqual(recipes[0].Ingredients.Count, resultCollection[1].Ingredients.Count);
            Assert.AreEqual(recipes[1].Ingredients.Count, resultCollection[0].Ingredients.Count);

            Assert.AreEqual(recipes[0].Ingredients[0].ingredient, resultCollection[1].Ingredients[0].ingredient);
            Assert.AreEqual(recipes[0].Ingredients[1].ingredient, resultCollection[1].Ingredients[1].ingredient);
            Assert.AreEqual(recipes[0].Ingredients[2].ingredient, resultCollection[1].Ingredients[2].ingredient);
            Assert.AreEqual(recipes[0].Ingredients[3].ingredient, resultCollection[1].Ingredients[3].ingredient);

            Assert.AreEqual(recipes[1].Ingredients[0].ingredient, resultCollection[0].Ingredients[0].ingredient);
            Assert.AreEqual(recipes[1].Ingredients[1].ingredient, resultCollection[0].Ingredients[1].ingredient);
        }
    }
}