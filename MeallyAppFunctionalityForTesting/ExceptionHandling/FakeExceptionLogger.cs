using MeallyApp.Resources.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyAppFunctionalityForTesting.ExceptionHandling
{
    public class FakeExceptionLogger : IExceptionLogger
    {
        public event MyEventHandler? exceptionAddedToFile;
        public string? exception;

        public FakeExceptionLogger()
        {
            exception = string.Empty;
        }

        public void ClearLog()
        {
            exception = string.Empty;
        }

        public void WriteToLog(string message)
        {
            exception = message;
        }

        public string? ReadFromLog()
        {
            return exception;
        }
    }
}
