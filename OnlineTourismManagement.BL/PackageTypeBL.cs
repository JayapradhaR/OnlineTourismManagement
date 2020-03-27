using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System.Collections.Generic;

namespace OnlineTourismManagement.BL
{
    //Package type interface
    public interface IPackageTypeBL
    {
        IEnumerable<PackageType> GetPackageTypes();
        void AddPackageType(PackageType packageType);
        PackageType GetPackageTypeById(int packageTypeId);
        void UpdatePackageType(PackageType packageType);
        void DeletePackageType(int id);
    }
    public class PackageTypeBL : IPackageTypeBL
    {
        IPackageType packageTypeDAL;
        public PackageTypeBL()
        {
            packageTypeDAL = new PackageTypeRepository();
        }
        public IEnumerable<PackageType> GetPackageTypes()
        {
            return packageTypeDAL.GetPackageTypes();//Call GetPackageTypes() to view package types
        }
        public void AddPackageType(PackageType packageTypes)
        {
            packageTypeDAL.AddPackageType(packageTypes);//Call AddPackageType() to add package type into database
        }
        public void UpdatePackageType(PackageType package)
        {
            packageTypeDAL.UpdatePackageType(package);//Call UpdatePackageType() to update the package types
        }
        public PackageType GetPackageTypeById(int packageId)
        {
            return packageTypeDAL.GetPackageTypeById(packageId);//Getting package types by id
        }
        public void DeletePackageType(int id)
        {
            packageTypeDAL.DeletePackageType(id);//Call DeletePackageType() to delete the package type
        }
    }
}
