using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStoreWeb.Models;

namespace PhoneStoreWeb.Controllers
{
    public class ProductDetailController : Controller
    {
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        // GET: ProductDetail
        
        public ActionResult getProductDetails(int id)
        {
            var v = from t in db.tb_Product
                    where  t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult getImage(int id)
        {
            var v = from t in db.tb_ProductImage
                    where t.id == id
                    select t;
            return View(v.ToList());
        }
    }
}