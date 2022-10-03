using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.Ingredients
{
    public class Ingredient
    {
        public Ingredient() {;}

        public Ingredient(Ingredients ingredient, string name, string image)
        {
            this.ingredient = ingredient;
            Name = name;
            Image = image;
        }

        public Ingredients ingredient { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }



    }
}
