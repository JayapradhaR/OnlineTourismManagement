using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class PackageRepository
    {
        static OnlineTourismDBContext context = new OnlineTourismDBContext();
        public static IEnumerable<PackageDetails> GetPackages()
        {
            return context.PackageDB.ToList();
        }
        public static void AddPackage(PackageDetails package)
        {
            context.PackageDB.Add(package);
            context.SaveChanges();
        }
        public static PackageDetails GetPackageById(int packageId)
        {
            return context.PackageDB.ToList().Where(id => id.PackageId == packageId).SingleOrDefault();
        }
        public static void UpdatePackage(PackageDetails package)
        {
            PackageDetails pack = GetPackageById(package.PackageId);
            context.Entry(pack).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
