using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using OnlineTourismManagement.BL;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineTourismManagement.Controllers
{
    [Authorize(Roles ="User")]
    public class OrderController : Controller
    {
        // GET: Order
        IPackageBL packageBL;
        ItineraryBL itineraryBL;
        IOrderBL orderBL;
        IUserBL userBL;
        public OrderController()
        {
            packageBL = new PackageBL();
            itineraryBL = new ItineraryBL();
            orderBL = new OrderBL();
            userBL = new AccountBL();
            //var UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OrderPackage(int PackageId)
        {
            Package packages = packageBL.GetPackageById(PackageId);
            TempData["PackageId"] = packages.PackageId;
            TempData["PackagePrice"] = packages.PackagePrice;
            //TempData["UserId"] = UserId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderPackage(OrderViewModel OrderDetails)
        {
            if (ModelState.IsValid)
            {
                string UserId =User.Identity.Name.ToString();
                Customer user = userBL.GetUsersByUserName(UserId);
                Order order = AutoMapper.Mapper.Map<OrderViewModel, Order>(OrderDetails);
                order.UserId = user.UserId;
                orderBL.AddOrderDetails(order);
                return RedirectToAction("ViewSummary",new { id = order.PackageId,OrderId = order.BookingId  });
            }
            return View();
        }
        [HttpGet]
        public ActionResult ViewSummary(int id,int OrderId)
        {
            dynamic details = new ExpandoObject();
            Package packages = packageBL.GetPackageById(id);
            IEnumerable<Itinerary> itinerary = itineraryBL.GetItineraryByPackage(id);
            Order order = orderBL.ViewOrderDetails(OrderId);
            details.Package = packages;
            details.Itinerary = itinerary;
            details.Order = order;
            return View(details);
        }
        public ActionResult ViewOrderDetails(int id)
        {
            Order order = orderBL.ViewOrderDetails(id);
            return View(order);
        }
    }
}