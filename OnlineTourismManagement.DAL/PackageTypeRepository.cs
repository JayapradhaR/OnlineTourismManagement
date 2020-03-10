using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.DAL
{
    public class PackageTypeRepository
    {
        public static IEnumerable<PackageType> GetPackageTypes()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageTypes.ToList();
            }
        }
        public static void AddPackageType(PackageType packageType)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.PackageTypes.Add(packageType);
                context.SaveChanges();
            }
        }
        public static PackageType GetPackageTypeById(int packageTypeId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageTypes.ToList().Where(id => id.PackageTypeId == packageTypeId).SingleOrDefault();
            }
        }
        public static void UpdatePackageType(PackageType packageType)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                //PackageDetails pack = GetPackageById(package.PackageId);
                context.Entry(packageType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
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
