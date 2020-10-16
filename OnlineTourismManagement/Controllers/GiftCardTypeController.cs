using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTourismManagement.Controllers
{
    public class GiftCardTypeController : Controller
    {
        IGiftCardTypeBL giftCardTypeBL;
        public GiftCardTypeController()
        {
            giftCardTypeBL = new GiftCardTypeBL();
        }
        // GET: GiftCardType
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddGiftCardType()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGiftCardType(GiftCardTypeViewModel giftCardType)
        {
            if(ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(giftCardType.ImageFile.FileName);
                string extension = Path.GetExtension(giftCardType.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                giftCardType.ImageSource = "~/Images/GiftCardTypeImages/" + fileName;
                GiftCardType cardType = AutoMapper.Mapper.Map<GiftCardTypeViewModel, GiftCardType>(giftCardType);
                fileName = Path.Combine(Server.MapPath("~/Images/GiftCardTypeImages/"), fileName);
                giftCardType.ImageFile.SaveAs(fileName);
                giftCardTypeBL.AddGiftCardType(cardType);
                return RedirectToAction("ViewGiftCardTypes");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            GiftCardType giftCardType = giftCardTypeBL.GetGiftCardTypeById(id);
            GiftCardTypeViewModel giftCardTypeViewModel = AutoMapper.Mapper.Map<GiftCardType, GiftCardTypeViewModel>(giftCardType);
            return View(giftCardTypeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include ="GiftCardTypeId,GiftCardTypeName,ImageSource,ImageFile")]GiftCardTypeViewModel giftCardType)
        {
                string fileName = Path.GetFileNameWithoutExtension(giftCardType.ImageFile.FileName);
                string extension = Path.GetExtension(giftCardType.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                giftCardType.ImageSource = "~/Images/GiftCardTypeImages/" + fileName;
                GiftCardType cardType = AutoMapper.Mapper.Map<GiftCardTypeViewModel, GiftCardType>(giftCardType);
                fileName = Path.Combine(Server.MapPath("~/Images/GiftCardTypeImages/"), fileName);
                giftCardType.ImageFile.SaveAs(fileName);
                GiftCardType giftCard = giftCardTypeBL.GetGiftCardTypeById(giftCardType.GiftCardTypeId);
                giftCard.GiftCardTypeName = giftCardType.GiftCardTypeName;
                giftCard.ImageSource = giftCardType.ImageSource;
                giftCardTypeBL.UpdateGiftCardType(giftCard);
                return RedirectToAction("ViewGiftCardTypes");
           
        }
        public ActionResult ViewGiftCardTypes()
        {
            IEnumerable<GiftCardType> giftCardTypes = giftCardTypeBL.GetGiftCardTypes();
            return View(giftCardTypes);
        }
    }
}