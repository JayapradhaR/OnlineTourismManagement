﻿using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class PackageRepository
    {
        public static IEnumerable<Package> GetPackages()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Packages.ToList();
            }
        }
        public static void AddPackage(Package package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Packages.Add(package);
                context.SaveChanges();
            }
        }
        public static Package GetPackageById(int packageId)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Packages.ToList().Where(id => id.PackageId == packageId).SingleOrDefault();
            }
        }
        public static void UpdatePackage(Package package)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                //PackageDetails pack = GetPackageById(package.PackageId);
                context.Entry(package).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void DeletePackage(int id)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                Package package = GetPackageById(id);
                context.Packages.Attach(package);
                context.Packages.Remove(package);
                context.SaveChanges();
            }
        }
    }
}
