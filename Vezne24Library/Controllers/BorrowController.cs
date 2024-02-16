using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;
using Vezne24Library.Models;
using Vezne24Library.Models.BorrowModels;

namespace Vezne24Library.Controllers
{
    [Authorize]
    public class BorrowController : Controller
    {
        private BorrowManager bom;
        private BookManager bm;
        private MemberManager mm;
        public BorrowController()
        {
            bom = new BorrowManager(new EfBorrowDal());
            bm = new BookManager(new EfBookDal());
            mm = new MemberManager(new EfMemberDal());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var borrowlist = bom.GetList();
            var booklist = bm.GetList();
            var memberlist = mm.GetList();

            BorrowViewModel borrowViewModel = new BorrowViewModel { Borrows = borrowlist, Books = booklist, Members = memberlist };
            return View(borrowViewModel);

        }
        public ActionResult Loans()
        {
            ViewBag.booklist = bm.GetList();
            ViewBag.memberlist = mm.GetList().Select(m => new {
                Id = m.Id,
                FullName = m.FirstName + " " + m.LastName
            }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Loans(Borrow borrow)
        {
            BorrowValidator bv = new BorrowValidator();
            ValidationResult result = bv.Validate(borrow);
            if (result.IsValid)
            {
                try
                {
                    borrow.EditDate = borrow.CreateDate = borrow.PeriodStartDate = DateTime.Now;
                    borrow.EditId = borrow.CreateId = 0;
                    borrow.PeriodFinishDate = DateTime.Now.AddDays(15);
                    borrow.Deleted = false;
                    bom.TAdd(borrow);
                    return RedirectToAction("Index");
                }
                catch (System.Exception)
                {
                    ViewBag.booklist = bm.GetList();
                    ViewBag.memberlist= mm.GetList().Select(m => new {
                        Id = m.Id,
                        FullName = m.FirstName + " " + m.LastName
                    }).ToList();
                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(borrow);
                }
                
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.booklist = bm.GetList();
            ViewBag.memberlist = mm.GetList().Select(m => new {
                Id = m.Id,
                FullName = m.FirstName + " " + m.LastName
            }).ToList();
            return View(borrow);
        }

        public ActionResult Pay(int id)
        {
            try
            {
                var model = bom.TGetById(id);
                model.ReturnedDate = DateTime.Now;
                model.Deleted = true;
                bom.TUpdate(model);
                ViewBag.Message = "Kitap iade edildi.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                ViewBag.Message = "Bir Hata Oluştu.";
                return RedirectToAction("Index");
            }
           
        }
    }
}