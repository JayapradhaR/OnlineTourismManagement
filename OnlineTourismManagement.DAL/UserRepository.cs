using OnlineTourismManagement.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class UserRepository
    { 
        //Getting user details from database
        public static IEnumerable<User> GetUsers()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Users.ToList();
            }
        }
        //Adding user details into database
        public static void AddUser(User user)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                SqlParameter firstName = new SqlParameter("@FirstName", user.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", user.LastName);
                SqlParameter mobileNumber = new SqlParameter("@MobileNumber", user.MobileNumber);
                SqlParameter gender = new SqlParameter("@Gender", user.Gender);
                SqlParameter dateofBirth = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                SqlParameter username = new SqlParameter("@Username", user.MailId);
                SqlParameter password = new SqlParameter("@Password", user.Password);
                SqlParameter role = new SqlParameter("@Role", user.UserRole);
                int result = context.Database.ExecuteSqlCommand("sp_InsertUser @FirstName,@LastName,@MobileNumber,@Gender,@DateOfBirth,@Username,@Password,@Role", firstName, lastName, mobileNumber, gender, dateofBirth, username, password, role);
            }
        }
        //Validate the login details
        public static string ValidateSignIn(string username,string password)
        {
            string userRole="";
            IEnumerable<User> users;
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                users = context.Users.ToList();
            }
            foreach (var value in users)
            {
                if (username == value.MailId && password == value.Password) //Check if the login is validate login or not
                {
                    userRole = value.UserRole;
                    break;
                }
            }
            return userRole;
        }
    }
}

