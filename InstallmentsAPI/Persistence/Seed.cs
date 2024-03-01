using InstallmentsAPI.Entities.Models;
using InstallmentsAPI.Entities.Resources;
using Microsoft.AspNetCore.Identity;

namespace InstallmentsAPI.Persistence;
public class Seed
{
    public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        if (!roleManager.Roles.Any())
        {
            roleManager.CreateAsync(new Role { Name = Policies.Admin }).Wait();
            roleManager.CreateAsync(new Role { Name = Policies.Moderator }).Wait();
        }
        if (!userManager.Users.Any())
        {
            var admin = new User
            {
                Email = "admin@admin.com",
                UserName = "Admin",
            };

            userManager.CreateAsync(admin, "Admin-12345678900").Wait();
            admin = userManager.FindByEmailAsync(admin.Email).Result;
            userManager.AddToRoleAsync(admin, Policies.Admin).Wait();
            userManager.AddToRoleAsync(admin, Policies.Moderator).Wait();
        }
    }
}