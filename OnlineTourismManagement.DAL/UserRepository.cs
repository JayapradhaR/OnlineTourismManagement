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
        static OnlineTourismDBContext context = new OnlineTourismDBContext();
        public static IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public static void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public static string ValidateSignIn(string username,string password)
        {
            string userRole="";
            IEnumerable<User> users = context.Users.ToList();
            foreach (var value in users)
            {
                if (username == value.MailId && password == value.Password)
                {
                    userRole = value.UserRole;
                    break;
                }
            }
            return userRole;
        }
    }
}

