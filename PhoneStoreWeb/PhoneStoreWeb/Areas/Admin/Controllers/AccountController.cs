using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStoreWeb.Models;

namespace PhoneStoreWeb.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        public ActionResult Index()
        {
            UserLogin userLogin = (UserLogin)Session["USER_SESSION"];
            if (userLogin != null)
            {
                return View(userLogin);
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item=db.tb_User.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(tb_User model)
        {
            if (ModelState.IsValid)
            {
                var item = db.tb_User.Find(model.id);
                if (PhoneStoreWeb.Models.Common.Encryption.GetHashMD5(model.password) != item.password)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                    return View("Edit");
                }
                else
                {
                    item.firstName = model.firstName;
                    item.lastName = model.lastName;
                    item.email = model.email;
                    item.image = model.image;
                    item.password = PhoneStoreWeb.Models.Common.Encryption.GetHashMD5(model.password);
                    db.tb_User.Attach(item);
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    UserLogin userLogin = (UserLogin)Session["USER_SESSION"];
                    if (userLogin != null)
                    {
                        userLogin.FirstName = model.firstName;
                        userLogin.LastName = model.lastName;
                        userLogin.Email = model.email;
                        userLogin.Image = model.image;
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult EditPassword(int id)
        {
            var item = db.tb_User.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditPassword(tb_User model, String newPass, String confirm)
        {
            if (ModelState.IsValid)
            {
                var item = db.tb_User.Find(model.id);
                if (PhoneStoreWeb.Models.Common.Encryption.GetHashMD5(model.password) != item.password)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                    return View("EditPassword");
                }
                else
                {
                    if (newPass != confirm)
                    {
                        ModelState.AddModelError("", "Mật khẩu xác minh không đúng");
                        return View("EditPassword");
                    }
                    else
                    {
                        if (newPass.Length < 6)
                        {
                            ModelState.AddModelError("", "Mật khẩu ít nhất 6 ký tự");
                            return View("EditPassword");
                        }
                        else
                        {
                            item.password = PhoneStoreWeb.Models.Common.Encryption.GetHashMD5(newPass);
                            db.tb_User.Attach(item);
                            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        
                    }
                }
            }
            return View(model);
        }
    }
}