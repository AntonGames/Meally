using MeallyDBapi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeallyDBapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        IMeallyDataRepository _meallyDataRepository;

        public FoodController(IMeallyDataRepository context)
        {
            _meallyDataRepository = context;
        }

        [HttpGet("GetIngredients")]
        public IActionResult GetIngredients()
        {
            return Ok(_meallyDataRepository.GetAllIngredients());
        }

        [HttpGet("GetRecipes")]
        public IActionResult GetRecipes()
        {
            return Ok(_meallyDataRepository.GetAllRecipes());
        }

        [HttpGet("GetRecipe/{id}")]
        public IActionResult GetRecipe(int id)
        {
            return Ok(_meallyDataRepository.GetRecipe(id));
        }
    }
}
