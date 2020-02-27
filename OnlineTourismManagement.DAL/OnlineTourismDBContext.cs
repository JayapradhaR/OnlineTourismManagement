using System.Data.Entity;
using OnlineTourismManagement.Entity;

namespace OnlineTourismManagement.DAL
{
    public class OnlineTourismDBContext : DbContext
    {
        public OnlineTourismDBContext():base("Connection")
        {

        }
        public DbSet<UserDetails> UserDB { get; set; }
        public DbSet<PackageDetails> PackageDB { get; set; }
    }
}
