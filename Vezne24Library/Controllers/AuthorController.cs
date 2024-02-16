using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Vezne24Library.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private AuthorManager aum;
        public AuthorController()
        {
            aum = new AuthorManager(new EfAuthorDal());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = aum.GetList().Where(x => x.Deleted == false).ToList();
            return View(result);
        }
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Add()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(Author author)
        {
            AuthorValidator av = new AuthorValidator();
            ValidationResult result = av.Validate(author);
            if (result.IsValid)
            {
                try
                {
                    author.EditId = author.CreateId = 0;
                    author.CreateDate = author.EditDate = DateTime.Now;
                    author.Deleted = false;
                    aum.TAdd(author);
                    return RedirectToAction("Index", "Author");
                }
                catch (Exception)
                {
                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(author);
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var result = aum.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Author author)
        {
           
            AuthorValidator av = new AuthorValidator();
            ValidationResult result = av.Validate(author);
            if (result.IsValid)
            {
                try
                {
                    author.EditId = 0;
                    author.EditDate = DateTime.Now;
                    aum.TUpdate(author);
                    return RedirectToAction("Index", "Author");
                }
                catch (Exception)
                {

                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(author);
                }
               
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(author);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(int id)
        {
            try
            {
                var result = aum.TGetById(id);
                result.Deleted= true;
                aum.TUpdate(result);
                return RedirectToAction("Index", "Author");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index", "Author");
            }
        }


        //Hata Var
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                //var result = aum.TGetById(id);
                aum.Delete(id);
                return RedirectToAction("Index", "Author");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index", "Author");
            }
            
        }

    }
}
