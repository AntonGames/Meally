using MeallyApp.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyAppTests
{
    public class TestIngredient
    {
        [TestCase(0.6, 0.5, -1)]
        [TestCase(0.5, 0.6, 1)]
        [TestCase(0.5, 0.5, 0)]
        public void CompareToTest(double rec1C, double rec2C, int result)
        {
            Recipe rec1 = new Recipe("Pie", new List<Ingredient>(), "Something", "IMG.png");
            Recipe rec2 = new Recipe("Bread", new List<Ingredient>(), "Something", "IMG.png");

            rec1.Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));
            rec1.Ingredients.Add(new Ingredient(Ingredients.Flour, "IMG"));
            rec1.Ingredients.Add(new Ingredient(Ingredients.Eggs, "IMG"));
            rec1.Ingredients.Add(new Ingredient(Ingredients.Lemon, "IMG"));

            rec2.Ingredients.Add(new Ingredient(Ingredients.Flour, "IMG"));
            rec2.Ingredients.Add(new Ingredient(Ingredients.Butter, "IMG"));

            rec1.Compatibility = rec1C;
            rec2.Compatibility = rec2C;

            int actual = rec1.CompareTo(rec2);

            Assert.AreEqual(result, actual);
        }
    }
}
