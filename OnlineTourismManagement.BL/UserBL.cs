using OnlineTourismManagement.Entity;
using OnlineTourismManagement.DAL;
namespace OnlineTourismManagement.BL
{
    public class UserBL
    {
        public static int AddUser(UserDetails user)
        {
            return UserRepository.AddUser(user);
        }
    }
}
