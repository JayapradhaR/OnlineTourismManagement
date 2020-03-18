using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System.Collections.Generic;

namespace OnlineTourismManagement.BL
{
    public class PackageTypeBL
    {
        public static IEnumerable<PackageType> GetPackageTypes()
        {
            return PackageTypeRepository.GetPackageTypes();
        }
        public static void AddPackageType(PackageType packageType)
        {
            PackageTypeRepository.AddPackageType(packageType);
        }
        public static void UpdatePackageType(PackageType package)
        {
            PackageTypeRepository.UpdatePackageType(package);
        }
        public static PackageType GetPackageTypeById(int packageId)
        {
            return PackageTypeRepository.GetPackageTypeById(packageId);
        }
        public static void DeletePackageType(int id)
        {
            PackageTypeRepository.DeletePackageType(id);
        }
    }
}
