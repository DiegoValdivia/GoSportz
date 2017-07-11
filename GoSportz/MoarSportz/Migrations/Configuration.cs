namespace MoarSportz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoarSportz.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoarSportz.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Roles.AddOrUpdate(
              p => p.Id,
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "1", Name = "admin" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "2", Name = "super" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "3", Name = "coach" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "4", Name = "player" }

            );
        }
    }
}
