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
        IPackageType packageType;
        public PackageTypeBL()
        {
            packageType = new PackageTypeRepository();
        }
        public IEnumerable<PackageType> GetPackageTypes()
        {
            return packageType.GetPackageTypes();//Call GetPackageTypes() to view package types
        }
        public void AddPackageType(PackageType packageTypes)
        {
            packageType.AddPackageType(packageTypes);//Call AddPackageType() to add package type into database
        }
        public void UpdatePackageType(PackageType package)
        {
            packageType.UpdatePackageType(package);//Call UpdatePackageType() to update the package types
        }
        public PackageType GetPackageTypeById(int packageId)
        {
            return packageType.GetPackageTypeById(packageId);//Getting package types by id
        }
        public void DeletePackageType(int id)
        {
            packageType.DeletePackageType(id);//Call DeletePackageType() to delete the package type
        }
    }
}
