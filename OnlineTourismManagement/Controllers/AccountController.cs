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
    public class AccountController : Controller
    {
        IUserBL userBL;
        public AccountController()
        {
            userBL = new AccountBL();
        }
       
        public ViewResult Index()
        {
            IEnumerable<Customer> user = userBL.GetUsers();
            return View(user);
        }
        //Create new account
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpViewModel user)  // Sign up details
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer userDetails = AutoMapper.Mapper.Map<SignUpViewModel, Customer>(user);
                    userBL.AddUser(userDetails); //Add account details into database
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
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel userDetail) //Sign in details
        {
            if (ModelState.IsValid)
            {
                Customer userDetails = AutoMapper.Mapper.Map<SignInViewModel, Customer>(userDetail);
                Customer user = userBL.ValidateSignIn(userDetails); //Validate login details
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
                    //Response.Write("Incorrect");
                    TempData["Message"] = "Username or password incorrect";
                   //Response.Write("<script language='javascript'>alert('Username or password incorrect');</script");

            }
            return RedirectToAction("SignIn", "Account");
        }
        //Logout the account
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Homepage");
        }
    }
}