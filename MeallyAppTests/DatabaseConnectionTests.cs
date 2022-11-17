using MeallyApp.Resources.Services;
using MeallyAppFunctionalityForTesting.ExceptionHandling;
using MeallyAppFunctionalityForTesting.Services;

namespace MeallyAppTests
{
    public class DatabaseConnectionTests
    {
        private FakeExceptionLogger logger;

        public DatabaseConnectionTests()
        {
            this.logger = new FakeExceptionLogger();
        }
        [Test]
        public async Task DatabaseConnectionTestValid()
        {
            logger.ClearLog();
            DatabaseConnection databaseConnection = new DatabaseConnection(logger);

            await databaseConnection.GetDBAsync();

            Assert.AreEqual(string.Empty, logger.ReadFromLog());
        }

        [Test]
        public async Task DatabaseConnectionTestInvalidBitApiKey()
        {
            logger.ClearLog();
            FakeDatabaseConnection databaseConnection = new FakeDatabaseConnection(logger);

            await databaseConnection.GetDBAsync();

            Assert.AreEqual("Error from sql server.", logger.ReadFromLog());
        }
    }
}
