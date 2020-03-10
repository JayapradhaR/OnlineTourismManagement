using System.Data.Entity;
using OnlineTourismManagement.Entity;

namespace OnlineTourismManagement.DAL
{
    public class OnlineTourismDBContext : DbContext
    {
        public OnlineTourismDBContext():base("Connection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
    }
}
