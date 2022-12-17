using Castle.DynamicProxy;
using Newtonsoft.Json;
using Serilog;
using System.Diagnostics;

namespace MeallyDBapi.Interceptors
{
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                invocation.Proceed();
                stopwatch.Stop();

                Console.WriteLine($"API Method {invocation.Method.Name}\n" + $"Parameters: {JsonConvert.SerializeObject(invocation.Arguments)}\n" +
                    $"Returned: {JsonConvert.SerializeObject(invocation.ReturnValue)}\n" + $"Method execution time in milliseconds: {JsonConvert.SerializeObject(stopwatch.ElapsedMilliseconds)}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error happened in method: {invocation.Method}. Error: {JsonConvert.SerializeObject(ex)}");
            }
        }
    }
}
