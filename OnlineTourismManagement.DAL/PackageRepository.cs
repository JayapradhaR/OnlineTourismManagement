using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class PackageRepository
    {
      
        public static IEnumerable<PackageDetails> GetPackages()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageDB.ToList();
            }
        }
        public static void AddPackage(PackageDetails package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.PackageDB.Add(package);
                context.SaveChanges();
            }
        
        }
        public static PackageDetails GetPackageById(int packageId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageDB.ToList().Where(id => id.PackageId == packageId).SingleOrDefault();
            }
        }
        public static void UpdatePackage(PackageDetails package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                //PackageDetails pack = GetPackageById(package.PackageId);
                context.Entry(package).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void DeletePackage(int id)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                PackageDetails package = GetPackageById(id);
                context.PackageDB.Remove(package);
                context.SaveChanges();
            }
        }
    }
}
