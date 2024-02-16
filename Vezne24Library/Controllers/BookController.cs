using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using Vezne24Library.Models;
using Vezne24Library.Models.BookModels;

namespace Vezne24Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookManager bm;
        private AuthorManager aum;
        private PublisherManager pum;
        public BookController()
        {
            bm = new BookManager(new EfBookDal());
            aum = new AuthorManager(new EfAuthorDal());
            pum = new PublisherManager(new EfPublisherDal());
        }
        // GET: Book
        public ActionResult Index(string key)
        {
            var books = bm.GetList().Where(x => x.Deleted == false).ToList();
            var authors = aum.GetList();
            var publishers = pum.GetList();
            if (key == null)
            {
                BookViewModel bookViewModel = new BookViewModel { Books = books, Authors = authors, Publishers = publishers };
                return View(bookViewModel);
            }
            else
            {
                var filters = books.Where(x => x.Name.ToLower().Contains(key.ToLower()) || x.Barcode.ToLower().Contains(key.ToLower())).ToList();
                BookViewModel bookViewModel = new BookViewModel { Books = filters, Authors = authors, Publishers = publishers };
                return View(bookViewModel);
            }
            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var book=bm.TGetById(id);
            //var authors = aum.GetList();
            //var publishers = pum.GetList();
            ViewBag.authors = aum.GetList(); ;
            ViewBag.publisher = pum.GetList();
            //BookEditViewModel bookViewModel = new BookEditViewModel { Books = books, Authors = authors, Publishers = publishers };
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            BookValidator pv = new BookValidator();
            ValidationResult result = pv.Validate(book);
            if (result.IsValid)
            {
                try
                {
                    var bookDetail = bm.TGetById(book.Id);
                    book.CreateDate= bookDetail.CreateDate;
                    book.CreateId= bookDetail.CreateId;
                    book.Deleted=bookDetail.Deleted;
                    book.EditDate = DateTime.Now;
                    book.CreateId =0;
                    bm.TUpdate(book);
                    return RedirectToAction("Index");
                }
                catch (System.Exception)
                {
                    ViewBag.authors = aum.GetList(); ;
                    ViewBag.publisher = pum.GetList();
                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(book);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.authors = aum.GetList(); ;
            ViewBag.publisher = pum.GetList();
            return View(book);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.authors = aum.GetList(); ;
            ViewBag.publisher = pum.GetList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Book book)
        {
            BookValidator pv = new BookValidator();
            ValidationResult result = pv.Validate(book);
            if (result.IsValid)
            {
                try
                {
                    book.CreateDate=book.EditDate=DateTime.Now;
                    book.CreateId = book.EditId = 0;
                    book.Deleted = false;
                    bm.TAdd(book);
                    return RedirectToAction("Index");
                }
                catch (System.Exception)
                {
                    ViewBag.authors = aum.GetList(); ;
                    ViewBag.publisher = pum.GetList();
                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(book);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.authors = aum.GetList(); ;
            ViewBag.publisher = pum.GetList();
            return View(book);
            
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(int id)
        {
            try
            {
                var result = bm.TGetById(id);
                result.Deleted = true;
                bm.TUpdate(result);
                return RedirectToAction("Index", "Book");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index", "Book");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                //var result = aum.TGetById(id);
                bm.Delete(id);
                return RedirectToAction("Index", "Book");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index", "Book");
            }
        }
    }
}