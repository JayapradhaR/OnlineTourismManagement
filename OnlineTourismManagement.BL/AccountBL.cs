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
        IUser user;
        public AccountBL()
        {
            user = new AccountRepository();    
        }
        public void AddUser(Account userDetails)
        { 
            user.AddUser(userDetails);
        }
        public IEnumerable<Account> GetUsers()
        {
            return user.GetUsers();
        }
        public Account ValidateSignIn(Account userDetails)
        {
            return user.ValidateSignIn(userDetails);
        }
    }
}
