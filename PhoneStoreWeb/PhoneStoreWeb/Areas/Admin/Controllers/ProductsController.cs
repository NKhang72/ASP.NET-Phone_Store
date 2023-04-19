using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhoneStoreWeb.Models;
using PagedList;

namespace PhoneStoreWeb.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        PhoneStoreEntities1 db = new PhoneStoreEntities1();
        // GET: Admin/Products
        public ActionResult Index (int? page )
        {
            IEnumerable<tb_Product> items = db.tb_Product.OrderByDescending(x => x.id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(tb_Product model, List<string> Images, List<int> rDefault)
        { 


         var v = from t in db.tb_Product
                 where t.Hide == true
                 select t;
            model.id = v.ToList().LastOrDefault().id + 1;
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.tb_ProductImage.Add(new tb_ProductImage
                            {
                                productId = model.id,
                                image = Images[i],
                                isDefault = true
                            });
                        }
                        else
                        {
                            model.tb_ProductImage.Add(new tb_ProductImage
                            {
                                productId = model.id,
                                image = Images[i],
                                isDefault = false
                            });
                        }
                    }
                }
                model.CreateDate = DateTime.Now;
                model.ModifierDate = DateTime.Now;
                var checkbox = Request.Form.GetValues("CheckBoxId")[0];
                if (checkbox == "true")
                {
                    model.Hide = true;
                }
                else
                {
                    model.Hide = false;
                }
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Meta))
                    model.Meta = PhoneStoreWeb.Models.Common.Filter.FilterChar(model.Title);
                db.tb_Product.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "id", "Title");
            return View(model);
        }
    }
}