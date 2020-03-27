using System.Data.Entity;
using OnlineTourismManagement.Entity;

namespace OnlineTourismManagement.DAL
{
    public class OnlineTourismDBContext : DbContext
    {
        public OnlineTourismDBContext() : base("Connection") //Call base class constructor to establish connection
        {

        }
        public DbSet<Account> Users { get; set; } //DbSet for Account entity
        public DbSet<Package> Packages { get; set; } //DbSet for Package entity
        public DbSet<PackageType> PackageTypes { get; set; } //DbSet for PackageType entity
        public DbSet<Itinerary> Itineraries { get; set; } // DbSet for Itinerary entity
        /// <summary>
        /// Stored procedure for insert,update and delete user details
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
            .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertUser"))
            .Update(sp => sp.HasName("sp_UpdateUser"))
            .Delete(sp => sp.HasName("sp_DeleteUser"))
            );
        }

    }
}
