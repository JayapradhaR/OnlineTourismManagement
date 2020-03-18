using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System.Collections.Generic;

namespace OnlineTourismManagement.BL
{
    public class PackageBL
    {
        public static IEnumerable<Package> GetPackages()
        {
            return PackageRepository.GetPackages();
        }
        public static void AddPackage(Package package)
        {
            PackageRepository.AddPackage(package);
        }
        public static void UpdatePackage(Package package)
        {
           PackageRepository.UpdatePackage(package);
        }
        public static Package GetPackageById(int packageId)
        {
            return PackageRepository.GetPackageById(packageId);
        }
        public static void DeletePackage(int id)
        {
            PackageRepository.DeletePackage(id);
        }

        public static void AddItinerary(List<Itinerary> itineraries)
        {
            ItineraryRepository.AddItinerary(itineraries);
        }

    }
}
