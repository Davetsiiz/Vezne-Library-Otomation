using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vezne24Library.Controllers
{
    [Authorize]
    public class PublisherController : Controller
    {
        private PublisherManager pum;
        public PublisherController()
        {
            pum = new PublisherManager(new EfPublisherDal());
        }
        [HttpGet]
        public ActionResult Index()
        {
            var result = pum.GetList().Where(x => x.Deleted == false).ToList();
            return View(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var result = pum.TGetById(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Publisher publisher)
        {
            PublisherValidator pv = new PublisherValidator();
            ValidationResult result = pv.Validate(publisher);
            if (result.IsValid)
            {
                try
                {
                    var pubResult = pum.TGetById(publisher.Id);
                    publisher.EditId = 0;
                    publisher.EditDate = DateTime.Now;
                    publisher.CreateDate = pubResult.CreateDate;
                    publisher.CreateId = pubResult.CreateId;
                    publisher.Deleted = pubResult.Deleted;
                    pum.TUpdate(publisher);
                    return RedirectToAction("Index", "Publisher");
                }
                catch (Exception)
                {

                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(publisher);
                }

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(publisher);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Publisher publisher)
        {
            PublisherValidator pv = new PublisherValidator();
            ValidationResult result = pv.Validate(publisher);
            if (result.IsValid)
            {
                try
                {
                    publisher.EditId = publisher.CreateId = 0;
                    publisher.CreateDate = publisher.EditDate = DateTime.Now;
                    publisher.Deleted = false;
                    pum.TAdd(publisher);
                    return RedirectToAction("Index", "Publisher");
                }
                catch (Exception)
                {

                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(publisher);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(int id)
        {
            try
            {
                var result = pum.TGetById(id);
                result.Deleted = true;
                pum.TUpdate(result);
                return RedirectToAction("Index", "Publisher");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index", "Publisher");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                //var result = aum.TGetById(id);
                pum.Delete(id);
                return RedirectToAction("Index", "Publisher");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index", "Publisher");
            }
        }
       
    }
}