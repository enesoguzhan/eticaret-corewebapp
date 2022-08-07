using AOP.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace AOP.Aspects
{
    public class LogAspect : MethodInterception
    {
        protected override void OnSuccess(IInvocation invocation)
        {
            Console.WriteLine($"{invocation.Method.Name} Method Çalıştı");
            Console.WriteLine($"{invocation.Method.Name} Method Çalıştı");
        }
    }
}
