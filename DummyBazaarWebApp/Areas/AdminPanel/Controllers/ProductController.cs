using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Areas.AdminPanel.Controllers
{
    public class ProductController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();

        // GET: AdminPanel/Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories.ToList(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            return View();
        }
    }
}