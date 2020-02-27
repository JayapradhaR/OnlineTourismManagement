using OnlineTourismManagement.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class UserRepository
    {
        //static SqlConnection connection;

        public static IEnumerable<UserDetails> GetUsers()
        {
            OnlineTourismDBContext context = new OnlineTourismDBContext();
            return context.UserDB.ToList();
        }
        public static void AddUser(UserDetails user)
        {
            OnlineTourismDBContext context = new OnlineTourismDBContext();
            context.UserDB.Add(user);
            context.SaveChanges();
        }
        
    }
}
