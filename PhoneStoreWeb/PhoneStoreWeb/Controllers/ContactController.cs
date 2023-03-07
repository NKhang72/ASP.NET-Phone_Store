using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStoreWeb.Models;

namespace PhoneStoreWeb.Controllers
{
    public class ContactController : Controller
    {
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        public ActionResult Index()
        {
            return View();
        }
    }
        
}