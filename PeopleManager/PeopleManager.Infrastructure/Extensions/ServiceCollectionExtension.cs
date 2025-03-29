using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeopleManager.Core.Interfaces;
using PeopleManager.Infrastructure.Persistence;
using PeopleManager.Infrastructure.Persistence.Repositories;

namespace PeopleManager.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'PeopleManagerContext' not found.");

            services.AddDbContext<PeopleManagerContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}