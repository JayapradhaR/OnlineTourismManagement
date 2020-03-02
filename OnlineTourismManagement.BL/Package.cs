using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.BL
{
    public class Package
    {
        public static IEnumerable<PackageDetails> GetPackages()
        {
            return PackageRepository.GetPackages();
        }
        public static void AddPackage(PackageDetails package)
        {
            PackageRepository.AddPackage(package);
        }
        public static void UpdatePackage(PackageDetails package)
        {
            PackageRepository.UpdatePackage(package);
        }
        public static PackageDetails GetPackageById(int packageId)
        {
            return PackageRepository.GetPackageById(packageId);
        }
    }
}
