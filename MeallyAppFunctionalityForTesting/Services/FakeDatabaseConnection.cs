using MeallyApp.Resources.EventArguments;
using MeallyApp.Resources.ExceptionHandling;
using MeallyApp.Resources.Ingredients;
using MeallyApp.Resources.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyAppFunctionalityForTesting.Services
{
    public class FakeDatabaseConnection : IDatabaseConnection
    {
        public event EventHandler<RecipesLoadedEventArgs>? RecipesLoaded;
        public IExceptionLogger logger;
        private List<Recipe> database = new List<Recipe>();

        public FakeDatabaseConnection(IExceptionLogger logger)
        {
            this.logger = logger;
        }

        public async Task GetDBAsync()
        {
            database.Clear();
            // Setup bit.io database connection
            var bitHost = "db.bit.io";
            var bitUser = "";
            var bitDbName = "LorryGailius/Meally";
            var bitApiKey = "++v2_3usyy_JDfAYxxp5xTy6SgPPGEiZF4";   //added 2 +

            var cs = $"Host={bitHost};Username={bitUser};Password={bitApiKey};Database={bitDbName}";

            using var con = new NpgsqlConnection(cs);

            try
            {
                await con.OpenAsync();

                con.TypeMapper.UseJsonNet();
                using (var cmd = new NpgsqlCommand(@"SELECT json_build_object('Name', Name, 'Image', Image, 'Compatibility', Compatibility, 'RecipeInstructions', RecipeInstructions, 'Ingredients', Ingredients) FROM ""Recipes"";", con))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var temp = reader.GetFieldValue<Recipe>(0);
                        database.Add(temp);
                    }
                }
                con.Close();
            }
            catch (System.Net.Sockets.SocketException)
            {
                logger.WriteToLog("Couldn't connect to the database, check your internet connection.");
            }
            catch (NpgsqlException)
            {
                logger.WriteToLog("Error from sql server.");
            }
            catch (Exception ex)
            {
                logger.WriteToLog("Error.");
            }
        }

        public List<Recipe> GetRecipeList()
        {
            return database;
        }
    }
}
