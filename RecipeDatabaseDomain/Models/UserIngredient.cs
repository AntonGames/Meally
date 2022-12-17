using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDatabaseDomain.Models
{
    public class UserIngredient
    {
        public UserIngredient(int userId, int ingredientId)
        {
            UserId = userId;
            IngredientId = ingredientId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int IngredientId { get; set; }
    }
}
