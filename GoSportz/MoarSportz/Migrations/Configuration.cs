namespace MoarSportz.Migrations
{
    using MoarSportz.Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var passwordHasher = new PasswordHasher();

            string passwordHash = passwordHasher.HashPassword("test123");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 

            var adminRoleName = "admin";
            var managerRoleName = "manager";
            var athleteRoleName = "athlete";

            context.Roles.AddOrUpdate(
              p => p.Id,
                new IdentityRole { Id = "1", Name = adminRoleName },
                new IdentityRole { Id = "2", Name = managerRoleName },
                new IdentityRole { Id = "3", Name = athleteRoleName }
            );

            var admin = new ApplicationUser { Email = "admin@test.com", UserName = "admin@test.com", PasswordHash = passwordHash };
            var manager = new ApplicationUser { Email = "manager@test.com", UserName = "manager@test.com", PasswordHash = passwordHash };
            var athlete = new ApplicationUser { Email = "athlete@test.com", UserName = "athlete@test.com", PasswordHash = passwordHash };

            context.Users.AddOrUpdate(
                u => u.UserName,
                admin,
                manager,
                athlete);

            // roles need to exist before they can be assigned to users. 
            // 'update-dabase' will get to these before inserting roles records to db
            if (roleManager.RoleExists(adminRoleName) && roleManager.RoleExists(managerRoleName) && roleManager.RoleExists(athleteRoleName))
            {
                userManager.AddToRole(admin.Id, adminRoleName);
                userManager.AddToRole(manager.Id, managerRoleName);
                userManager.AddToRole(athlete.Id, athleteRoleName);
            }

            context.Athletes.AddOrUpdate(
                a => a.AthleteId,
                new Athlete { AspNetUser = athlete.Id });
        }
    }
}
