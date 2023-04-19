using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStoreWeb.Models;

namespace PhoneStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        public ActionResult Index()
        {

            var v = from t in db.tb_Product
                    where t.Hide == true
                    select t;
            return View();
        }
        public ActionResult getProductbyMeta(int id)
        {
            var v = from t in db.tb_Product
                    where t.ProductCategory == id.ToString()
                    select t;
            return View(v.ToList());
        }
        public ActionResult getCategoriesSlideBar()
        {
            var v = from t in db.tb_ProductCategory
                    where t.Hide == true
                    select t;
            return PartialView(v.ToList());
        }
    }
}