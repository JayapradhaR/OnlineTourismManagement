namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineTourismManagement.DAL.OnlineTourismDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineTourismManagement.DAL.OnlineTourismDBContext";
        }

        protected override void Seed(OnlineTourismManagement.DAL.OnlineTourismDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
