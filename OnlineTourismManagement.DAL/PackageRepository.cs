using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class PackageRepository
    {
        //Getting package details from database
        public static IEnumerable<Package> GetPackages()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Packages.ToList();
            }
        }
        //Add package details
        public static void AddPackage(Package package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Packages.Add(package);  //Adding package into database
                context.SaveChanges();
            }
        }
        //Get package using id
        public static Package GetPackageById(int packageId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Packages.Where(id => id.PackageId == packageId).SingleOrDefault();
            }
        }
        //Update the package details
        public static void UpdatePackage(Package package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                //PackageDetails pack = GetPackageById(package.PackageId);
                context.Entry(package).State = EntityState.Modified;//Updating package in database
                context.SaveChanges();
            }
        }
        //Delete package
        public static void DeletePackage(int id)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                Package package = GetPackageById(id);
                context.Packages.Attach(package);
                context.Packages.Remove(package); //Removing package from database
                context.SaveChanges();
            }
        }
    }
}
