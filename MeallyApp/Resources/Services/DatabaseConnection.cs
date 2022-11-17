using MeallyApp.Resources.EventArguments;
using MeallyApp.Resources.ExceptionHandling;
using MeallyApp.Resources.Ingredients;
using Npgsql;

namespace MeallyApp.Resources.Services
{
    public class DatabaseConnection : IDatabaseConnection
    {
        // 5. Standart event
        public event EventHandler<RecipesLoadedEventArgs> RecipesLoaded;
        public IExceptionLogger logger;
        private List<Recipe> database = new List<Recipe>();

        public DatabaseConnection(IExceptionLogger logger)
        {
            this.logger = logger;
        }

        // Get recipes from database
        public async Task GetDBAsync()
        {
            database.Clear();
            // Setup bit.io database connection
            var bitHost = "db.bit.io";
            var bitUser = "";
            var bitDbName = "LorryGailius/Meally";
            var bitApiKey = "v2_3usyy_JDfAYxxp5xTy6SgPPGEiZF4";

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
                // invoking a standart event
                RecipesLoaded(this, new RecipesLoadedEventArgs() { message = "All recipes loaded succesfully from the database." });
            }
            catch (System.Net.Sockets.SocketException)
            {
                logger.WriteToLog("Couldn't connect to the database, check your internet connection.");
            }
            catch (Npgsql.NpgsqlException)
            {
                logger.WriteToLog("An existing connection was forcibly closed by the remote host.");
            }
        }

        public List<Recipe> GetRecipeList()
        {
            return database;
        }
    }
}
