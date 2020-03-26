using System.Web.Mvc;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Models;
using System.Collections.Generic;
using System.Web.Security;
using System;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace OnlineTourismManagement.Controllers
{
    // [Authentication]
    public class AccountController : Controller
    {
        // GET: User
        IUserBL users;
        public AccountController()
        {
            users = new AccountBL();
        }
        [ActionName("Registration")]
        public ViewResult Index()
        {
            IEnumerable<Account> user = users.GetUsers();
            return View("Index");
        }
        //Create new account
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel user)  // Sign up details
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account userDetails = AutoMapper.Mapper.Map<SignUpViewModel, Account>(user);
                    users.AddUser(userDetails); //Add account details into database
                    TempData["Message"] = "Registration successfully completed";
                    return RedirectToAction("SignIn");
                }
                return View();
            }
            catch(DbUpdateException)
            {
                return RedirectToAction("Error", "Error");
            }
        }
        //Login 
        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(SignInViewModel userDetail) //Sign in details
        {
            if (ModelState.IsValid)
            {
                Account userDetails = AutoMapper.Mapper.Map<SignInViewModel, Account>(userDetail);
                Account user = users.ValidateSignIn(userDetails); //Validate login details
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.MailId, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.MailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.UserRole);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Home", "Homepage");
                }
                else
                    Response.Write("Username or password incorrect");
            }
            return View();
        }
        //Logout the account
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Homepage");
        }
        public ViewResult DisplayUsers(Account user)
        {
            return View();
        }

    }
}