using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.DependencyAutofac;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//AutoFactý burada kullanacaðýmýzý bildiriyoruz
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new AutoFacModule()));

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(s => s.MapDefaultControllerRoute());
app.Run();
