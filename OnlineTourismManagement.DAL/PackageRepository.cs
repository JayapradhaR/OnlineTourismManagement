using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public interface IPackage //interface for package 
    {
        IEnumerable<Package> GetPackages();
        void AddPackage(Package package);
        Package GetPackageById(int packageId);
        void UpdatePackage(Package package);
        void DeletePackage(int id);
        IEnumerable<Package> SearchPackageByName(string search,string searchBy);
        IEnumerable<Package> GetPackagesByTypeId(int id);
    }
    /// <summary>
    /// This PackageRepository performs CRUD operations for packages
    /// </summary>
    public class PackageRepository : IPackage
    {
        //Getting package details from database
        public IEnumerable<Package> GetPackages()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Packages.Include("PackageTypes").ToList();
            }
        }
        //Add package details
        public void AddPackage(Package package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Packages.Add(package);  //Adding package into database
                context.SaveChanges();
            }
        }
        //Get package using id
        public Package GetPackageById(int packageId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Packages.Where(id => id.PackageId == packageId).SingleOrDefault();
            }
        }
        //Update the package details
        public void UpdatePackage(Package package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Entry(package).State = EntityState.Modified;//Updating package in database
                context.SaveChanges();
            }
        }
        //Delete package
        public void DeletePackage(int id)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                Package package = GetPackageById(id);
                context.Packages.Attach(package);
                context.Packages.Remove(package); //Removing package from database
                context.SaveChanges();
            }
        }
        //View Package using package type id
        public IEnumerable<Package> GetPackagesByTypeId(int id)
        {
            using (OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                return context.Packages.Include("PackageTypes").Where(typeId => typeId.PackageTypeId == id).ToList();
            }
        }
        //Search package by package name
        public IEnumerable<Package> SearchPackageByName(string search,string searchBy)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                if (searchBy == "PackageName")
                    return context.Packages.Where(name => name.PackageName.Contains(search)).ToList();
                else
                    return context.Packages.Include("PackageTypes").Where(type => type.PackageTypes.PackageTypeName.Contains(search)).ToList();
            }
        }
    }
}
