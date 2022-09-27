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
        private List<Ingredient> inventory;

        public List<Ingredient> Inventory { get { return inventory; } }

        public User(List<Ingredient> inventory)
        {
            this.inventory = inventory;
        }
    }
}
