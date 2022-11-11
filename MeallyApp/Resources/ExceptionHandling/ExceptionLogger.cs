using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.ExceptionHandling
{
    public delegate void MyEventHandler(string value);

    public static class ExceptionLogger
    {
        private static string logFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Log.txt");

        // 5. Custom event 
        public static event MyEventHandler exceptionAddedToFile;

        public static void ClearLog()
        {
            File.WriteAllText(logFileName, string.Empty);
        }

        public static void WriteToLog(string message)
        {
            File.AppendAllText(logFileName, message + Environment.NewLine);
            exceptionAddedToFile("New exception added: " + message);
        }

        public static void ReadFromLog()
        {
            if (File.Exists(logFileName))
            {
                System.Diagnostics.Debug.WriteLine("All exceptions during current session: ");

                string[] buffer = File.ReadAllLines(logFileName);
                int num = 1;
                foreach (string line in buffer)
                {
                    System.Diagnostics.Debug.WriteLine(num + ". " + line);
                    num++;
                }
            }            
        }
    }
}
