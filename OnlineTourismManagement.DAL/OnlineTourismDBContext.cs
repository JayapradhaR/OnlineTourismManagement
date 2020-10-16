using System.Data.Entity;
using OnlineTourismManagement.Entity;

namespace OnlineTourismManagement.DAL
{
    public class OnlineTourismDBContext : DbContext
    {
        public OnlineTourismDBContext() : base("Connection") //Call base class constructor to establish connection
        {

        }
        public DbSet<Customer> Users { get; set; } //DbSet for Account entity
        public DbSet<Package> Packages { get; set; } //DbSet for Package entity
        public DbSet<PackageType> PackageTypes { get; set; } //DbSet for PackageType entity
        public DbSet<Itinerary> Itineraries { get; set; } // DbSet for Itinerary entity
        public DbSet<Order> OrderDetails { get; set; }//DbSet for Order entity
        public DbSet<GiftCardType> GiftCardTypes { get; set; }//DbSet for GiftCardType entity
        public DbSet<GiftCard> GiftCards { get; set; }//DbSet for GiftCard entity
        public DbSet<GiftCardOrder> GiftCardOrders { get; set; }//DbSet for GiftCardOrders entity
        /// <summary>
        /// Stored procedure for insert,update and delete user details
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertUser"))
            .Update(sp => sp.HasName("sp_UpdateUser"))
            .Delete(sp => sp.HasName("sp_DeleteUser"))
            );
        }

    }
}
