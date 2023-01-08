using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Controllers
{
    public class ProductController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                Product p = db.Products.Find(id);
                return View(p);
            }
            return RedirectToAction("Index","Home");
            
        }
    }
}