using AOP.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace BusinessLayer.DependencyAutofac
{
    public class AutoFacModule : Module
    {
        //Reflection Nedir ? 
        //Programın derleme aşamasındaki bütün metotların ve classların hakkında bilgi almamızı olanak sağlayan bir kütüphanidir. Microsoftun kendi dahili kütüphanesidir.

        protected override void Load(ContainerBuilder builder)
        {
           
            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelect()
                }).SingleInstance();
        }
    }
}
