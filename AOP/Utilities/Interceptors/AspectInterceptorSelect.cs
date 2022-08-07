using Castle.DynamicProxy;
using System.Reflection;

namespace AOP.Utilities.Interceptors
{
    public class AspectInterceptorSelect : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodIncterceptorBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodIncterceptorBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            return classAttributes.ToArray();
        }
    }
}
