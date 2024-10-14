using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using System.Reflection;

namespace SchoolProject.core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;    
        }

    }
}
