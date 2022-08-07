using AOP.Utilities.Interceptors;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace AOP.Aspects
{
    public class PerformanceAspect : MethodInterception
    {
        private Stopwatch _Stopwatch;
        public PerformanceAspect()
        {
            _Stopwatch = new Stopwatch();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _Stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            Console.WriteLine("Performans : " + invocation.Method.DeclaringType.FullName + " - " + invocation.Method.Name + " Süre : " + _Stopwatch.Elapsed.TotalSeconds.ToString());

            _Stopwatch.Stop();
        }
    }
}
