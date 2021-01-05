using OnlineTourismManagement.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System;

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
                user.Password = EncryptPassword(user.Password);
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
       
                users = context.Users.ToList().Where(id=>userDetails.MailId==id.MailId&&userDetails.Password==DecryptPassword(id.Password)).SingleOrDefault();//Check if user details are validate or not
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
        public string EncryptPassword(string password)
        {
            Byte[] encryptByte = new Byte[password.Length];
            encryptByte = System.Text.Encoding.UTF8.GetBytes(password);
            string encryptCode = Convert.ToBase64String(encryptByte);
            return encryptCode;
        }
        public string DecryptPassword(string encryptedCode)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] decryptByte = Convert.FromBase64String(encryptedCode);
            int charCount = utf8Decode.GetCharCount(decryptByte, 0, decryptByte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(decryptByte, 0, decryptByte.Length, decoded_char, 0);
            string password = new String(decoded_char);
            return password;
        }
        
    }
}

