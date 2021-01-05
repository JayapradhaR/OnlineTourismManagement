using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public interface IPackageType //Interface for packagetype
    {
        IEnumerable<PackageType> GetPackageTypes();
        void AddPackageType(PackageType packageType);
        PackageType GetPackageTypeById(int packageTypeId);
        void UpdatePackageType(PackageType packageType);
        IEnumerable<PackageType> SearchResults(string search);
        void DeletePackageType(int id);
    }
    /// <summary>
    /// This PackageTypeRepository class performs the CRUD operations for package types
    /// </summary>
    public class PackageTypeRepository : IPackageType
    {
        //Getting package types from database
        public IEnumerable<PackageType> GetPackageTypes()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageTypes.ToList();
            }
        }
        //Add the packages types
        public void AddPackageType(PackageType packageType)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.PackageTypes.Add(packageType);
                context.SaveChanges();
            }
        }
        //Get the package types using id
        public PackageType GetPackageTypeById(int packageTypeId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.PackageTypes.ToList().Where(id => id.PackageTypeId == packageTypeId).SingleOrDefault();
            }
        }
        public IEnumerable<PackageType> SearchResults(string search)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                return context.PackageTypes.Where(type => type.PackageTypeName.Contains(search)).ToList();
            }
        }

        //Update package types if required
        public void UpdatePackageType(PackageType packageType)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Entry(packageType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Delete package types 
        public void DeletePackageType(int id)
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
