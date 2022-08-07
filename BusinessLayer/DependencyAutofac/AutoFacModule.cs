using AOP.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using DataAccessLayer;

namespace BusinessLayer.DependencyAutofac
{
    public class AutoFacModule : Module
    {
        //Reflection Nedir ? 
        //Programın derleme aşamasındaki bütün metotların ve classların hakkında bilgi almamızı olanak sağlayan bir kütüphanidir. Microsoftun kendi dahili kütüphanesidir.

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EticaretContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<CategoriesService>().As<ICategoriesService>();
            builder.RegisterType<CustomersService>().As<ICustomersService>();
            builder.RegisterType<OrdersRelationService>().As<IOrdersRelationService>();
            builder.RegisterType<ProductsService>().As<IProdutctsService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
