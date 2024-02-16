using BusinnessLayer.Concrete;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vezne24Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        private MemberManager mm;
        public MemberController()
        {
            mm = new MemberManager(new EfMemberDal());
        }
        public ActionResult Index(string key)
        {
            if (key == null)
            {
                var result = mm.GetList();
                return View(result);
            }
            else
            {
                var result = mm.GetList().Where(x => x.FirstName.ToLower().Contains(key.ToLower()) || x.LastName.ToLower().Contains(key.ToLower()) || x.Email.ToLower().Contains(key.ToLower()))
                   .ToList();
                return View(result);
            }


        }
    }
}