
using RecipeDatabaseDomain;
using RecipeDatabaseDomain.Models;
using RecipeDatabaseDomain.ViewModels;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MeallyDBapi.Infrastructure
{
    public class MeallyDataRepository : IMeallyDataRepository
    {
        private readonly RecipeContext context;

        public MeallyDataRepository(RecipeContext context)
        {
            this.context = context;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return context.Ingredients.Where(x => x.Id > 0).ToList();
        }

        public List<RecipeViewModel> GetAllRecipes()
        {
            List<Recipe> recipes = context.Recipes.Where(x => x.Id > 0).ToList();
            //List<RecipeIngredient> recipeIngredients = context.RecipeIngredients.Where(x => x.Id > 0).ToList();
            List<RecipeViewModel> recipeViewModels = new List<RecipeViewModel>();

            for (int i = 0; i < recipes.Count; i++)
            {
                List<Ingredient> ingredients = GetRecipeIngredients(recipes[i].Id);
                recipeViewModels.Add(new RecipeViewModel(recipes[i], ingredients));
            }

            return recipeViewModels;
        }

        public List<Ingredient> GetRecipe(int id)
        {
            Recipe recipe = context.Recipes.First(x => x.Id == id);
            List<Ingredient> ingredients = GetRecipeIngredients(id);
            return ingredients;
        }

        private List<Ingredient> GetRecipeIngredients(int recipeId)
        {
            List<RecipeIngredient> recipeIngredients = context.RecipeIngredients.Where(x => x.RecipeID == recipeId).ToList();

            List<Ingredient> ingredientsForRecipe = new List<Ingredient>();
            for (int i = 0; i < recipeIngredients.Count; i++)
            {
                Ingredient? ingredientToAdd = GetIngredient(recipeIngredients[i].IngredientID);
                if(ingredientToAdd != null)
                {
                    ingredientsForRecipe.Add(ingredientToAdd);
                }
            }

            return ingredientsForRecipe;
        }

        private Ingredient? GetIngredient(int ingredientId)
        {
            return context.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        private List<Ingredient> GetUserInventory(int userId)
        {
            List<UserIngredient> userIngredients = context.UserIngredients.Where(x => x.UserId == userId).ToList();
            List<Ingredient> inventory = new List<Ingredient>();

            for (int i = 0; i < userIngredients.Count; i++)
            {
                Ingredient? ingredient = GetIngredient(userIngredients[i].IngredientId);

                if(ingredient != null)
                {
                    inventory.Add(ingredient);
                }
            }

            return inventory;
        }

        public void RegisterUser(UserAccount userAccount)
        {
            userAccount.Password = Hash(userAccount.Password);
            userAccount.ConfirmPassword = userAccount.Password;
            context.UserAccounts.Add(userAccount);
            context.SaveChanges();
        }
        
        public bool VerifyData(UserAccount userAccount, out string message)
        {
            UserAccount? acc = context.UserAccounts.FirstOrDefault(x => x.UserName == userAccount.UserName);

            if (acc != null)
            {
                message = "Username is already in use";
                return false;
            }

            message = "User has been registered";
            return true;
        }

        private const int _saltSize = 16; // 128 bits
        private const int _keySize = 32; // 256 bits
        private const int _iterations = 100000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        private const char segmentDelimiter = ':';

        public static string Hash(string input)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );
        }

        public static bool Verify(string input, string hashString)
        {
            string[] segments = hashString.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }

        public List<Ingredient>? VerifyUser(string username, string password)
        {
            UserAccount? acc = context.UserAccounts.FirstOrDefault(x => x.UserName == username);
            if (acc == null)
            {
                return null;
            }
            Debug.WriteLine(acc.UserName + "   username acc");

            if (Verify(password, acc.Password))
            {
                Debug.WriteLine("tesingas");
                return GetUserInventory(acc.UserID);
            }

            return null;
        }

        private int GetUserIdByUsername(string username)
        {
            return context.UserAccounts.First(x => x.UserName == username).UserID;
        }

        public void DeleteUserIngredients(string username)
        {
            List<UserIngredient> currentInventory = GetUserIngredients(GetUserIdByUsername(username));
            foreach(UserIngredient item in currentInventory)
            {
                context.UserIngredients.Remove(item);
            }

            context.SaveChanges();
        }

        public List<UserIngredient> GetUserIngredients(int UserId)
        {
            return context.UserIngredients.Where(x => x.UserId == UserId).ToList();
        }

        public bool UpdateUserInventory(UserIngredientsRequest request)
        {
            int UserId = GetUserIdByUsername(request.Username);
            int count = 0;
            for (int i = 0; i < request.Ingredients.Count; i++)
            {
                if (context.UserIngredients.Add(new UserIngredient(UserId, request.Ingredients[i].Id)) != null)
                {
                    count++;
                }
            }

            context.SaveChanges();

            if (count == request.Ingredients.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
