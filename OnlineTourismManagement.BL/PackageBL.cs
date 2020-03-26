using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System.Collections.Generic;

namespace OnlineTourismManagement.BL
{
    public interface IPackageBL
    {
        IEnumerable<Package> GetPackages();
        void AddPackage(Package package);
        Package GetPackageById(int packageId);
        void UpdatePackage(Package package);
        void DeletePackage(int id);
    }
    public class PackageBL : IPackageBL
    {
        IPackage package;
        public PackageBL()
        {
            package = new PackageRepository();
        }
        public IEnumerable<Package> GetPackages()
        {
            return package.GetPackages();//Call GetPackages() to view package details
        }
        public void AddPackage(Package packageDetails)
        {
            package.AddPackage(packageDetails);//Call AddPackage() to add the package details
        }
        public void UpdatePackage(Package packageDetails)
        {
            package.UpdatePackage(packageDetails);//Call UpdatePackage() to update package details
        }
        public Package GetPackageById(int packageId)
        {
            return package.GetPackageById(packageId);//Get package details by using package id
        }
        public void DeletePackage(int id)
        {
            package.DeletePackage(id);//Call DeletePackage() to delete package id
        }
    }
}
