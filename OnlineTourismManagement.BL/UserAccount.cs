using OnlineTourismManagement.Entity;
using OnlineTourismManagement.DAL;
using System.Collections.Generic;
namespace OnlineTourismManagement.BL
{
    public class UserAccount
    {
        public static void AddUser(User user)
        {
            UserRepository.AddUser(user);
        }
        public static IEnumerable<User> GetUsers()
        {
            return UserRepository.GetUsers();
        }
        public static string ValidateLogIn(string username,string password)
        {
            return UserRepository.ValidateSignIn(username, password);
        }
    }
}
