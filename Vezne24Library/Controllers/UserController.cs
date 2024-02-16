using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataLayer.Concrete;
using DataLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Vezne24Library.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        Context c=new Context();
        private MemberManager mm;
        // GET: User
        public UserController()
        {
            mm= new MemberManager(new EfMemberDal());
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Member member)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            try
            {
                var model = mm.GetList().Where(x => x.Email == member.Email && x.Password == member.Password);
                if (model.Any())
                {
                    FormsAuthentication.SetAuthCookie(model.FirstOrDefault().UserName, false);
                    Response.Redirect("/Home/Error");
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ViewBag.error = "Giriş verileri hatalı!";
                    return View(member);
                }
              
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Member member)
        {
            RegisteValidator av = new RegisteValidator();
            ValidationResult result = av.Validate(member);
            if (result.IsValid)
            {
                try
                {
                    var model = mm.GetList().Where(x => x.Email == member.Email).ToList();
                    if (model==null)
                    {
                        member.UserName = member.FirstName + member.LastName;
                        member.EditId = member.CreateId = 0;
                        member.EditDate = member.CreateDate = DateTime.Now;
                        member.RoleId = 4;
                        mm.TAdd(member);
                        if (User.Identity.IsAuthenticated)
                        {
                            FormsAuthentication.SignOut();
                        }
                        return RedirectToAction("Index", "Author");
                    } 
                    else
                    {
                        ViewBag.Message = "Mail adresiniz kayıtlıdır.";
                        return View(member);
                    }
                }
                catch (Exception)
                {

                    ViewBag.Message = "Bir Hata Oluştu.";
                    return View(member);
                }

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(member);
        }

        public ActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("login", "User");
        }
    }
}