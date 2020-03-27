using OnlineTourismManagement.Entity;
using OnlineTourismManagement.DAL;
using System.Collections.Generic;
namespace OnlineTourismManagement.BL
{
    public interface IUserBL
    {
        IEnumerable<Account> GetUsers();
        void AddUser(Account user);
        Account ValidateSignIn(Account userDetails);
    }
    public class AccountBL:IUserBL
    {
        IUser userDAL;
        public AccountBL()
        {
            userDAL = new AccountRepository();    
        }
        public void AddUser(Account userDetails)
        { 
            userDAL.AddUser(userDetails); //Add account details
        }
        public IEnumerable<Account> GetUsers()
        {
            return userDAL.GetUsers();
        }
        public Account ValidateSignIn(Account userDetails)
        {
            return userDAL.ValidateSignIn(userDetails); //Validate signin details
        }
    }
}
