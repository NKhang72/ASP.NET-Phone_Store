using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStoreWeb.Models;


namespace PhoneStoreWeb.Controllers
{
    public class HamburgerMenuController : Controller
    {
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        // GET: HamburgerMenu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getHamburgerMenu()
        {
            var v = from t in db.tb_Menu
                    where t.Hide == true
                    select t;
            return PartialView(v.ToList());
        }
    }
}