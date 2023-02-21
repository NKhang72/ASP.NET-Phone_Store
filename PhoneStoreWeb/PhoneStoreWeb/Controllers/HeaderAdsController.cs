using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStoreWeb.Models;

namespace PhoneStoreWeb.Controllers
{
    public class HeaderAdsController : Controller
    {
        PhoneStoreEntities1 db=new PhoneStoreEntities1();
        // GET: HeaderAds
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getAds()
        {
            var v = from t in db.tb_Header
                    where t.ads != null 
                    select t;
            return PartialView(v.ToList());
        }
    }
}