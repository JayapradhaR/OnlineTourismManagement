using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineTourismManagement.Entity;

namespace OnlineTourismManagement.DAL
{
    public class DBContext : DbContext
    {
        public DBContext():base("Connection")
        {

        }
        public DbSet<UserDetails> UserDB { get; set; }
    }
}
