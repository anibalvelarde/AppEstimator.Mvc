using Microsoft.Owin;
using Owin;
using Autofac.Integration.Mvc;
using Autofac.Integration.Owin;
using Autofac;
using AppEstimator.Mvc.App_Start;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(AppEstimator.Mvc.Startup))]
namespace AppEstimator.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterModule(new AppEstimatorMvcModule());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Owin Setup...
            ConfigureAuth(app);
            
            // Autofac Middleware...
            app.UseAutofacMiddleware(container);
        }
    }
}
