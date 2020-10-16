using OnlineTourismManagement.Entity;
using OnlineTourismManagement.DAL;
using System.Collections.Generic;
namespace OnlineTourismManagement.BL
{
    public interface IUserBL
    {
        IEnumerable<Customer> GetUsers();
        void AddUser(Customer user);
        Customer ValidateSignIn(Customer userDetails);
        Customer GetUsersByUserName(string UserName);
    }
    public class AccountBL:IUserBL
    {
        IUser userDAL;
        public AccountBL()
        {
            userDAL = new AccountRepository();    
        }
        public void AddUser(Customer userDetails)
        { 
            userDAL.AddUser(userDetails); //Add account details
        }
        public IEnumerable<Customer> GetUsers()
        {
            return userDAL.GetUsers();
        }
        public Customer ValidateSignIn(Customer userDetails)
        {
            return userDAL.ValidateSignIn(userDetails); //Validate signin details
        }
        public Customer GetUsersByUserName(string UserName)
        {
            return userDAL.GetUsersByUserName(UserName);
        }
    }
}
