using PhoneStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStoreWeb.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        PhoneStoreEntities1 db = new PhoneStoreEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getNewsbyMeta(String meta)
        {
            var v = from t in db.tb_News
                    where t.Meta == meta
                    select t;
            return View(v.ToList());
        }
    }
}