using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.ExceptionHandling
{
    public interface IExceptionLogger
    {
        public event MyEventHandler exceptionAddedToFile;
        public void ClearLog();

        public void WriteToLog(string message);

        public void ReadFromLog();
    }
}
