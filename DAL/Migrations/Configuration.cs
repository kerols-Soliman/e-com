namespace DAL.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //IdentityRole role = new IdentityRole("Admin");
            //context.Roles.Add(role);
            ApplicationUserIdentity user = new ApplicationUserIdentity { UserName = "UserAdmin", PasswordHash = "12345678" };
            ApplicationUserManager manager = new ApplicationUserManager();
            manager.CreateAsync(user);
            manager.AddToRoleAsync(user.Id, "Admin");
        }
    }
}
