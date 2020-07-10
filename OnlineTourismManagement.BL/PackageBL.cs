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
        IEnumerable<Package> GetPackageByTypeId(int id);
    }
    public class PackageBL : IPackageBL
    {
        IPackage packageDAL;
        public PackageBL()
        {
            packageDAL = new PackageRepository();
        }
        public IEnumerable<Package> GetPackages()
        {
            return packageDAL.GetPackages();//Call GetPackages() to view package details
        }
        public void AddPackage(Package packageDetails)
        {
            packageDAL.AddPackage(packageDetails);//Call AddPackage() to add the package details
        }
        public void UpdatePackage(Package packageDetails)
        {
            packageDAL.UpdatePackage(packageDetails);//Call UpdatePackage() to update package details
        }
        public Package GetPackageById(int packageId)
        {
            return packageDAL.GetPackageById(packageId);//Get package details by using package id
        }
        public void DeletePackage(int id)
        {
            packageDAL.DeletePackage(id);//Call DeletePackage() to delete package id
        }

        public IEnumerable<Package> GetPackageByTypeId(int id)
        {
            return packageDAL.GetPackagesByTypeId(id); // View package by type id
        }
    }
}
