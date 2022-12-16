using MeallyDBapi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RecipeDatabaseDomain.Models;
using System.Diagnostics;

namespace MeallyDBapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMeallyDataRepository repository;

        public UserController(IMeallyDataRepository repo)
        {
            repository = repo;
        }
        
        [HttpPost("VerifyUser")]
        public IActionResult VerifyUser(string username, string password)
        {
            //string username = HttpContext.Current.Request.QueryString["username"];
            //string password = Request.QueryString["password"];
            Debug.WriteLine("Iejo i funkcija");
            List<Ingredient>? inventory = repository.VerifyUser(username, password);
            if (inventory != null)
            {
                return Ok(inventory);
            }
            else
            {
                return NotFound();
            }
        }
        /*
        [HttpPost("UpdateInventory")]
        public IActionResult UpdateInv(string username, [FromBody]List<object> list)
        {
            repository.DeleteUserIngredients(username);
        }
        */
        
    }
}
