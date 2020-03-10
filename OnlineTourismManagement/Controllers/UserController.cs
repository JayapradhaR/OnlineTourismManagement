using System.Web.Mvc;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Models;
using System.Collections.Generic;
using OnlineTourismManagement.AuthData;

namespace OnlineTourismManagement.Controllers
{
   // [Authentication]
    public class UserController : Controller
    {
        // GET: User
        [ActionName("Registration")]
        public ViewResult Index()
        {
            IEnumerable<User> users = UserAccount.GetUsers();
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
            if (ModelState.IsValid)
            {
                User users = AutoMapper.Mapper.Map<SignUpViewModel, User>(user);
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
        public ActionResult SignIn(SignInViewModel user)
        {
            if(ModelState.IsValid)
            {
                string role=UserAccount.ValidateLogIn(user.MailId, user.Password);
                if (role == "User")
                    Response.Write("Login successful");
                else if (role == "Admin")
                    return RedirectToAction("ViewPackage", "Package");
                else
                    Response.Write("Username or password incorrect");

            }
            return View();
        }
        public ViewResult DisplayUsers(User user)
        {
            
            return View();
        }

    }
}