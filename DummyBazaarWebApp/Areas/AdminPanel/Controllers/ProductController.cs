using DummyBazaarWebApp.Areas.AdminPanel.Filters;
using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Areas.AdminPanel.Controllers
{
    [AdminAuthenticationFilter]
    public class ProductController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();

        // GET: AdminPanel/Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories.ToList(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase icon, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (icon != null)
                    {
                        FileInfo fi = new FileInfo(icon.FileName);
                        string name = Guid.NewGuid().ToString()+ fi.Extension;
                        model.IconPath = name;
                        icon.SaveAs(Server.MapPath($"~/Assets/ProductImage/{name}"));
                    }
                    else
                    { 
                        model.IconPath = "iconNone.png";
                    }
                    if (image != null)
                    {
                        FileInfo fi = new FileInfo(image.FileName);
                        string name = Guid.NewGuid().ToString() + fi.Extension;
                        model.ImagePath = name;
                        image.SaveAs(Server.MapPath($"~/Assets/ProductImage/{name}"));
                    }
                    else 
                    { 
                        model.ImagePath = "imageNone.png"; 
                    }
                    db.Products.Add(model);
                    db.SaveChanges();
                    ViewBag.message = "Ürün Ekleme Başarılı";
                }
                catch(Exception ex)
                {
                    ViewBag.message = "Ürün Ekleme Başarısız. Message = " + ex.Message;
                }
            }
            ViewBag.Category_ID = new SelectList(db.Categories.ToList(), "ID", "Name");
            return View();
        }
    }
}