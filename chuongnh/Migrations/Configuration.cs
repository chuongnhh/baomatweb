namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<chuongnh.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "chuongnh.Models.ApplicationDbContext";
        }

        protected override void Seed(chuongnh.Models.ApplicationDbContext context)
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
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                context.Roles.AddOrUpdate(
                  p => p.Name,
                  new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                  {
                      Name = "Admin"
                  }
                );
            }

            if (!context.Roles.Any(x => x.Name == "Member"))
            {
                context.Roles.AddOrUpdate(
                  p => p.Name,
                  new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                  {
                      Name = "Member"
                  }
                );
            }
        }
    }
}
