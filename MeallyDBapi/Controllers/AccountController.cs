using MeallyDBapi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RecipeDatabaseDomain;
using RecipeDatabaseDomain.Models;

namespace MeallyDBapi.Controllers
{
    public class AccountController : Controller
    {
        public readonly IMeallyDataRepository _meallyDataRepository;

        public AccountController(IMeallyDataRepository repo)
        {
            _meallyDataRepository = repo;
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                string? message;
                bool result = _meallyDataRepository.VerifyData(userAccount, out message);

                if (result)
                {
                    _meallyDataRepository.RegisterUser(userAccount);
                    TempData["Success"] = message;
                }
                else
                {
                    TempData["Error"] = message;
                }

                ModelState.Clear();
            }
            return View();
        }
    }
}
