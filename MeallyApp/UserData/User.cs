using MeallyApp.Resources.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.UserData
{
    public class User
    {
        public List<Ingredient> inventory;


        public User() {;}

        public User(List<Ingredient> inventory)
        {
            this.inventory = inventory;
        }

        public void PrintInv()
        {
            foreach (var ing in inventory)
            {
                Console.WriteLine(ing.Name);
            }
        }


    }
}
