using MeallyApp.Resources.ExceptionHandling;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyAppTests
{
    public class ExceptionTests
    {
        [TestCase("Hello")]
        [TestCase("Bye")]
        [TestCase("868855554")]
        [TestCase("868855554 \n laba diena,\nRamaus vakaro")]
        [TestCase("Sveiki Ponas Pomidore,\n malonu jus matyti.")]
        public void WriteToLogAndReadFromLogTest(string message)
        {
            ExceptionLogger logger = new ExceptionLogger();
            logger.ClearLog();
            logger.WriteToLog(message);
            string? buff = logger.ReadFromLog()?.TrimEnd('\r', '\n');
            Assert.AreEqual(message, buff);
        }
    }
}
