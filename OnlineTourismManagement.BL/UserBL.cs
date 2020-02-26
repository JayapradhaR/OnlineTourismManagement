using OnlineTourismManagement.Entity;
using OnlineTourismManagement.DAL;
using System.Collections.Generic;
namespace OnlineTourismManagement.BL
{
    public class UserBL
    {
        public static void AddUser(UserDetails user)
        {
            UserRepository.AddUser(user);
        }
        public static IEnumerable<UserDetails> GetUsers()
        {
            return UserRepository.GetUsers();
        }
    }
}
