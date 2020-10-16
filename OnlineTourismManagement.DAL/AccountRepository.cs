using OnlineTourismManagement.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public interface IUser
    {
        IEnumerable<Customer> GetUsers();
        void AddUser(Customer user);
        Customer ValidateSignIn(Customer userDetails);
        Customer GetUsersByUserName(string UserName);
    }
    /// <summary>
    /// This AccountRepository consists methods that is used to add the account details in database and validate the login details
    /// </summary>
    public class AccountRepository : IUser
    {
        //Getting user details from database
        public IEnumerable<Customer> GetUsers()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Users.ToList(); //User details
            }
        }
        //Adding user details into database
        public void AddUser(Customer user)
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
        public Customer ValidateSignIn(Customer userDetails)
        {
            Customer users;
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                users = context.Users.Where(id=>userDetails.MailId==id.MailId&&userDetails.Password==id.Password).SingleOrDefault();//Check if user details are validate or not
            }
            return users;
        }
        public Customer GetUsersByUserName(string UserName)
        {
            Customer users;
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                users = context.Users.Where(id => UserName == id.MailId).SingleOrDefault();
            }
            return users;
        }
    }
}

