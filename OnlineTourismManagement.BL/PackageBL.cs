using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.BL
{
    public class PackageBL
    {
        public static void AddPackage(PackageDetails package)
        {
            PackageRepository.AddPackage(package);
        }
    }
}
