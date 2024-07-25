using Backend.Data;
using Backend.Model;
using Backend.Repository;
using Backend.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var userRepository = serviceProvider.GetService<IUserRepository>();

        if (await roleManager.FindByNameAsync("Admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (await roleManager.FindByNameAsync("User") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        if (await roleManager.FindByNameAsync("Premium") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("Premium"));
        }

        var adminUser = await userManager.FindByEmailAsync("admin@example.com");
        if (adminUser == null)
        {
            adminUser = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
            var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        if ((await userRepository.FindUsersByEmailAsync("admin@example.com")).Count() == 0)
        {
            var admin = new User { Username = "admin", Email = "admin@example.com", BirthDate = DateTime.Parse("2000-01-01") };
            await userRepository.AddAsync(admin);
            await userRepository.CompleteAsync();
        }
        
    }
}