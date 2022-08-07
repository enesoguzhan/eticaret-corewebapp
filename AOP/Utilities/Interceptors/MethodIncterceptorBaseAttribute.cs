using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Utilities.Interceptors
{
    public abstract class MethodIncterceptorBaseAttribute : Attribute, IInterceptor
    {
        // Bu Metot sayesinde bütün işlemler sırasıyla gerçekleşiyor.
        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
