using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDatabaseDomain.Models
{
    public class UserIngredientsRequest
    {
        public string Username { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}
