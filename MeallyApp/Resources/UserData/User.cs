using Flurl.Http.Configuration;
using MeallyApp.Resources.Ingredients;
using System.Diagnostics;

namespace MeallyApp.UserData
{
    public static class User
    {
        public static string BaseUrl = "https://localhost:44393";

        public static string UserName;

        public static List<Ingredient> inventory = new List<Ingredient>();

        public static void PrintInv()
        {
            foreach(Ingredient A in inventory)
            {
                Debug.WriteLine(A);
            }
        }

    }
}
