using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PeopleManager.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (identityDbContext.Database.IsSqlServer())
                identityDbContext.Database.Migrate();

            await roleManager.CreateAsync(new IdentityRole("Admin"));

            var defaultUser = new ApplicationUser { UserName = "felipe@email", Email = "felipe@email" };
            await userManager.CreateAsync(defaultUser, "User@123");

            var adminUserName = "admin@localhost";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, "Admin@123");

            adminUser = await userManager.FindByNameAsync(adminUserName);

            if (adminUser != null)
                await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
