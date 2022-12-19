using System.Text.RegularExpressions;

namespace MeallyApp.Resources.Ingredients
{
    public class Ingredient : IEquatable<Ingredient>
    {
        public Ingredient() {;}

        public Ingredient(string DisplayName, string image)
        {
            this.DisplayName = DisplayName;
            this.Image = image;
        }

        public int Id { get; set; }

        public string DisplayName { get; set; } 

        public string Image { get; set; }

        public bool Equals(Ingredient other)
        {
            if (DisplayName == other.DisplayName) { return true; }
            return false;   
        }

        // Regex usage
        public override string ToString()
        {
            return DisplayName;
        }

    }
}
