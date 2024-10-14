using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrustructure.Repository.IRepository;
using SchoolProject.Infrustructure.Repository;
using SchoolProject.Infrustructure.Bases;

namespace SchoolProject.Infrustructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
