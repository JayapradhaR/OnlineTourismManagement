using System.Web.Mvc;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Models;
using System.Collections.Generic;
namespace OnlineTourismManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [ActionName("Registration")]
        public ViewResult Index()
        {
            IEnumerable<UserDetails> users = UserAccount.GetUsers();
            return View("Index");
        }
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel user)
        {
            UserDetails users = new UserDetails();
            
            if (ModelState.IsValid)
            {
                users.FirstName = user.FirstName;
                users.LastName = user.LastName;
                users.MobileNumber = user.MobileNumber;
                users.MailId = user.MailId;
                users.Password = user.Password;
                users.DateOfBirth = user.DateOfBirth;
                users.Gender = user.Gender;
                UserAccount.AddUser(users);
                TempData["Message"] = "Registration successfully completed";
                return RedirectToAction("SignIn");
            }
            return View();
        }
        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignIn(SignInViewModel user)
        {
            if(ModelState.IsValid)
            {
                bool isValid=UserAccount.ValidateLogIn(user.MailId, user.Password);
                if (isValid)
                    Response.Write("Login successful");
                else
                    Response.Write("Username or password incorrect");

            }
            return View();
        }
        public ViewResult DisplayUsers(UserDetails user)
        {
            
            return View();
        }

    }
}