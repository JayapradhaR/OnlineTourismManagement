using OnlineTourismManagement.Entity;

namespace OnlineTourismManagement.DAL
{
    public class PackageRepository
    {
        static OnlineTourismDBContext context = new OnlineTourismDBContext();
        public static void AddPackage(PackageDetails package)
        {
            context.PackageDB.Add(package);
            context.SaveChanges();
        }
    }
}
