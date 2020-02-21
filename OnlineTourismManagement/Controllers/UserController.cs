using System.Web.Mvc;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.BL;
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
        public ActionResult SignUp(UserDetails user)
        {
            if (ModelState.IsValid)
            {
                int rows=UserBL.AddUser(user);
                if (rows >= 1)
                {
                    TempData["Message"] = "Registration successfully completed";
                }
                return RedirectToAction("SignIn");
            }
            return View();

        }

        public ActionResult SignIn()
        {
            return View();
        }

    }
}