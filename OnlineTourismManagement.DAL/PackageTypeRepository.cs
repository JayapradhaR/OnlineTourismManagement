using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class PackageTypeRepository
    {
        //Getting package types from database
        public static IEnumerable<PackageType> GetPackageTypes()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageTypes.ToList();
            }
        }
        //Add the packages types
        public static void AddPackageType(PackageType packageType)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.PackageTypes.Add(packageType);
                context.SaveChanges();
            }
        }
        //Get the package types using id
        public static PackageType GetPackageTypeById(int packageTypeId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageTypes.ToList().Where(id => id.PackageTypeId == packageTypeId).SingleOrDefault();
            }
        }
        //Update package types if required
        public static void UpdatePackageType(PackageType packageType)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                //PackageDetails pack = GetPackageById(package.PackageId);
                context.Entry(packageType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Delete package types 
        public static void DeletePackageType(int id)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                PackageType packageType = GetPackageTypeById(id);
                context.PackageTypes.Attach(packageType);
                context.PackageTypes.Remove(packageType);
                context.SaveChanges();
            }
        }
    }
}
