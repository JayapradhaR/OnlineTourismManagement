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
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ActionResult SignUp()
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
                users.ConfirmPassword = user.ConfirmPassword;
                users.DateOfBirth = user.DateOfBirth;
                //users.UserRole = user.UserRole;
                users.Gender = user.Gender;
                UserBL.AddUser(users);
                TempData["Message"] = "Registration successfully completed";
                return RedirectToAction("SignIn");
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(SignInViewModel user)
        {
            return View();
        }
        public ActionResult DisplayUsers(UserDetails user)
        {
            IEnumerable<UserDetails> users = UserBL.GetUsers();
            return View(users);
        }

    }
}