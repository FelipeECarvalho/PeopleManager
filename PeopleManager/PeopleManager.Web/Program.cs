using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeopleManager.Application.Services;
using PeopleManager.Core.Interfaces;
using PeopleManager.Infrastructure;
using PeopleManager.Infrastructure.Identity;
using PeopleManager.Infrastructure.Persistence.Repositories;
using System.Threading.Tasks;

namespace PeopleManager.Web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // seeding the application
            using (var scope = app.Services.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;

                var identityContext = scopedProvider.GetRequiredService<AppIdentityDbContext>();
                var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await AppIdentityDbContextSeed.SeedAsync(identityContext, userManager, roleManager);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
