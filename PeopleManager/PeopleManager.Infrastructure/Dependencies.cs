using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleManager.Infrastructure.Identity;
using PeopleManager.Infrastructure.Persistence;

namespace PeopleManager.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<PeopleManagerContext>(c
                => c.UseSqlServer(configuration.GetConnectionString("PeopleManagerContext")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}