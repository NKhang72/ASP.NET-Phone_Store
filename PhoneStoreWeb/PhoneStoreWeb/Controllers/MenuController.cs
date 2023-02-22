﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStoreWeb.Models;

namespace PhoneStoreWeb.Controllers
{
   
    public class MenuController : Controller
    {
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getMenu()
        {
            var v= from t in db.tb_Menu
                   where t.Hide==true
                   select t;
            return PartialView(v.ToList());
        }
    }
}