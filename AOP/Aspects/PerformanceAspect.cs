using AOP.Utilities.Interceptors;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace AOP.Aspects
{
    public class PerformanceAspect : MethodInterception
    {
        private Stopwatch stopwatch;
        public PerformanceAspect()
        {
            stopwatch = new Stopwatch();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            Console.WriteLine($"Performans: {invocation.Method.DeclaringType.FullName} - {invocation.Method.Name} Süre : {stopwatch.Elapsed.TotalSeconds.ToString()}");
        }
    }
}
