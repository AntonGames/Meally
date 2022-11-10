using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeallyApp.Resources.ExceptionHandling
{
    public static class ExceptionLogger
    {
        private static string logFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Log.txt");

        public static void ClearLog()
        {
            File.WriteAllText(logFileName, string.Empty);
        }

        public static void WriteToLog(string message)
        {
            File.AppendAllText(logFileName, message + Environment.NewLine);
        }

        public static void ReadFromLog()
        {
            if (File.Exists(logFileName))
            {
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
