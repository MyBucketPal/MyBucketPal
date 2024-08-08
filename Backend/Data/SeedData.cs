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
        var appRepository = serviceProvider.GetService<IUnitOfWork>();

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
        

       
        // Create Gizike IdentityUser and corresponding User
        var user2User = await userManager.FindByEmailAsync("vipgizi@gmail.com");
        if (user2User == null)
        {
            user2User = new IdentityUser { UserName = "GizikeVIP", Email = "vipgizi@gmail.com" };
            var result = await userManager.CreateAsync(user2User, "GiziPassword123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user2User, "User");
            }
        }
        if ((await userRepository.FindUsersByEmailAsync("vipgizi@gmail.com")).Count() == 0)
        {
            var user2 = new User { Username = "GizikeVIP", Email = "vipgizi@gmail.com", BirthDate = DateTime.Parse("1999-01-01"), Premium = true };
            await userRepository.AddAsync(user2);
            await userRepository.CompleteAsync();
        }

        // Create Bela IdentityUser and corresponding User
        var user3User = await userManager.FindByEmailAsync("kovacsbela@gmail.com");
        if (user3User == null)
        {
            user3User = new IdentityUser { UserName = "Béla", Email = "kovacsbela@gmail.com" };
            var result = await userManager.CreateAsync(user3User, "BelaPassword123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user3User, "User");
            }
        }
        if ((await userRepository.FindUsersByEmailAsync("kovacsbela@gmail.com")).Count() == 0)
        {
            var user3 = new User { Username = "Béla", Email = "kovacsbela@gmail.com", BirthDate = DateTime.Parse("1989-02-02"), Premium = false };
            await userRepository.AddAsync(user3);
            await userRepository.CompleteAsync();
        }

        // Create user4 (Szilvi) IdentityUser and corresponding User
        var user4User = await userManager.FindByEmailAsync("szilvi@gmail.com");
        if (user4User == null)
        {
            user4User = new IdentityUser { UserName = "Szilvi", Email = "szilvi@gmail.com" };
            var result = await userManager.CreateAsync(user4User, "SzilviPassword123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user4User, "User");
            }
        }
        if ((await userRepository.FindUsersByEmailAsync("szilvi@gmail.com")).Count() == 0)
        {
            var user4 = new User { Username = "Szilvi", Email = "szilvi@gmail.com", BirthDate = DateTime.Parse("2000-02-02"), Premium = false };
            await userRepository.AddAsync(user4);
            await userRepository.CompleteAsync();
        }

        // Create user5 (Tom) IdentityUser and corresponding User
        var user5User = await userManager.FindByEmailAsync("susuVip@gmail.com");
        if (user5User == null)
        {
            user5User = new IdentityUser { UserName = "Susu", Email = "susuVip@gmail.com" };
            var result = await userManager.CreateAsync(user5User, "SusuPassword123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user5User, "User");
            }
        }
        if ((await userRepository.FindUsersByEmailAsync("susuVip@gmail.com")).Count() == 0)
        {
            var user5 = new User { Username = "Susu", Email = "susuVip@gmail.com", BirthDate = DateTime.Parse("1998-03-03"), Premium = true };
            await userRepository.AddAsync(user5);
            await userRepository.CompleteAsync();
        }


   
        var types = await appRepository.Types.GetAllAsync();
        var plans = await appRepository.Plans.GetAllAsync();
        var planDetails = await appRepository.PlanDetails.GetAllAsync();
        var subscribers = await appRepository.Subscribers.GetAllAsync();

        // seed basic types 
        if (types.Count() == 0)
        {
            var type1 = new Backend.Model.Type { Description = "travel" };
            var type2 = new Backend.Model.Type { Description = "food" };
            var type3 = new Backend.Model.Type { Description = "party" };
            var type4 = new Backend.Model.Type { Description = "learn" };
            var type5 = new Backend.Model.Type { Description = "extreme sport" };
            var type6 = new Backend.Model.Type { Description = "fearful" };
            var type7 = new Backend.Model.Type { Description = "18plus" };
            var type8 = new Backend.Model.Type { Description = "loose weight" };
            await appRepository.Types.AddAsync(type1);
            await appRepository.Types.AddAsync(type2);
            await appRepository.Types.AddAsync(type3);
            await appRepository.Types.AddAsync(type4);
            await appRepository.Types.AddAsync(type5);
            await appRepository.Types.AddAsync(type6);
            await appRepository.Types.AddAsync(type7);
            await appRepository.Types.AddAsync(type8);
            await appRepository.CompleteAsync();
        }

        // seed plans all private

        if (plans.Count() == 0)

            // if plan can be private, than it cannot be
        {
            var plan1 = new Plan { Title = "Barbecue", City = "Budapest", TypeId = 2, Description = "Have a BBQ party", CreatedAt = new DateTime(2024, 02, 10), IsPrivate = false };
            var plan2 = new Plan { Title = "Bungee jumping", City = "London", TypeId = 5, Description = "Try bungee jumping before 40", CreatedAt = new DateTime(2021, 02, 03), IsPrivate = false };
            var plan3 = new Plan { Title = "Italy, Rome, Colosseum", City = "Rome", TypeId = 1, Description = "Watch Colosseum", CreatedAt = new DateTime(2023, 10, 03), IsPrivate = false };
            var plan4 = new Plan { Title = "Crouchet", City = "", TypeId = 4, Description = "Learn how to crouchet for grandchildren", CreatedAt = new DateTime(2020, 06, 20), IsPrivate = false };
            var plan5 = new Plan { Title = "Reach ideal weight", City = "", TypeId = 8, Description = "Loose 12 kg-s till the wedding", CreatedAt = new DateTime(2020, 06, 20), IsPrivate = false };

            await appRepository.Plans.AddAsync(plan1);
            await appRepository.Plans.AddAsync(plan2);
            await appRepository.Plans.AddAsync(plan3);
            await appRepository.Plans.AddAsync(plan4);
            await appRepository.Plans.AddAsync(plan5);
            await appRepository.CompleteAsync();
        }

        // seed plandetails
        if (planDetails.Count() == 0)
        {
            var planDetail1 = new PlanDetail { PlanId = 1, IsPrivate = false, SubscriptionDate = new DateTime(2024, 02, 20), DateFrom = new DateTime(2024, 02, 20), DateTo = new DateTime(2024, 02, 25), IsCompleted = false };
            var planDetail2 = new PlanDetail { PlanId = 3, IsPrivate = false, SubscriptionDate = new DateTime(2024, 02, 20), DateFrom = new DateTime(2024, 02, 20), DateTo = new DateTime(2024, 02, 25), IsCompleted = false };
            var planDetail3 = new PlanDetail { PlanId = 3, IsPrivate = false, SubscriptionDate = new DateTime(2024, 02, 20), DateFrom = new DateTime(2024, 03, 20), DateTo = new DateTime(2024, 03, 25), IsCompleted = false };
            var planDetail4 = new PlanDetail { PlanId = 4, IsPrivate = false, SubscriptionDate = new DateTime(2024, 02, 20), DateFrom = new DateTime(2024, 02, 20), DateTo = new DateTime(2024, 02, 25), IsCompleted = false };
            // 1 bungee compleeted ( 3 emberrel mjad subscribe)
            var planDetail5 = new PlanDetail { PlanId = 2, IsPrivate = false, SubscriptionDate = new DateTime(2023, 02, 20), DateFrom = new DateTime(2023, 08, 20), DateTo = new DateTime(2023, 08, 20), IsCompleted = true };
            // 1 bungee 
            var planDetail6 = new PlanDetail { PlanId = 2, IsPrivate = false, SubscriptionDate = new DateTime(2023, 05, 10), DateFrom = new DateTime(2023, 07, 20), DateTo = new DateTime(2023, 07, 20), IsCompleted = false };
          
            // 2 privát fogyi
            var planDetail7 = new PlanDetail { PlanId = 5, IsPrivate = true, SubscriptionDate = new DateTime(2023, 02, 20), DateFrom = new DateTime(2023, 02, 20), DateTo = new DateTime(2023, 08, 01), IsCompleted = false };


            await appRepository.PlanDetails.AddAsync(planDetail1);
            await appRepository.PlanDetails.AddAsync(planDetail2);
            await appRepository.PlanDetails.AddAsync(planDetail3);
            await appRepository.PlanDetails.AddAsync(planDetail4);
            await appRepository.PlanDetails.AddAsync(planDetail5);
            await appRepository.PlanDetails.AddAsync(planDetail6);
            await appRepository.PlanDetails.AddAsync(planDetail7);
            await appRepository.CompleteAsync();
        }

        if (subscribers.Count() == 0)
        {
            var subscriber1 = new Subscriber { PlanDetailId = 3, UserId =  2}; //ez maga a feliratkozás róma colosseum 2024/03
            var subscriber2 = new Subscriber { PlanDetailId = 3, UserId = 5 };
            var subscriber3 = new Subscriber { PlanDetailId = 1, UserId = 2 }; //barbecue
            var subscriber4 = new Subscriber { PlanDetailId = 1, UserId = 3 };
            var subscriber5 = new Subscriber { PlanDetailId = 1, UserId = 4 };
            var subscriber6 = new Subscriber { PlanDetailId = 2, UserId = 4 }; // róma február
            var subscriber7 = new Subscriber { PlanDetailId = 2, UserId = 4 };
            var subscriber8 = new Subscriber { PlanDetailId = 5, UserId = 2 }; // bungee
            var subscriber9 = new Subscriber { PlanDetailId = 5, UserId = 4 };
            var subscriber10 = new Subscriber { PlanDetailId = 5, UserId = 5 };
            var subscriber11 = new Subscriber { PlanDetailId = 7, UserId = 4 }; //fogyi

            await appRepository.Subscribers.AddAsync(subscriber1);
            await appRepository.Subscribers.AddAsync(subscriber2);
            await appRepository.Subscribers.AddAsync(subscriber3);
            await appRepository.Subscribers.AddAsync(subscriber4);
            await appRepository.Subscribers.AddAsync(subscriber5);
            await appRepository.Subscribers.AddAsync(subscriber6);
            await appRepository.Subscribers.AddAsync(subscriber7);
            await appRepository.Subscribers.AddAsync(subscriber8);
            await appRepository.Subscribers.AddAsync(subscriber9);
            await appRepository.Subscribers.AddAsync(subscriber10);
            await appRepository.Subscribers.AddAsync(subscriber11);
            await appRepository.CompleteAsync();

        }

    }
}