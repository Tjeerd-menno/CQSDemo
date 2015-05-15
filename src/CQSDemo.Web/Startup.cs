using System;
using Autofac;
using Autofac.Dnx;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace CQSDemo.Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // We add MVC here instead of in ConfigureServices.
            services.AddMvc();

            // Create the Autofac container builder.
            var builder = new ContainerBuilder();

            // Add any Autofac modules or registrations.
            builder.RegisterModule(new RelatiesModule());

            // Populate the services.
            builder.Populate(services);

            // Build the container.
            var container = builder.Build();

            // Resolve and return the service provider.
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes => {
                routes.MapRoute(
                    "default",
                    "{controller}/{action}/{id?}",
                    new {controller = "Home", action = "Index"});
            });
        }
    }
}
