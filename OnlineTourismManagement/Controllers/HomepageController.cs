using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTourismManagement.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        [ActionName("Home")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}