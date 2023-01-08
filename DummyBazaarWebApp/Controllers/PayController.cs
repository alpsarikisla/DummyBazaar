using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Controllers
{
    public class PayController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();
        // GET: Pay
        [HttpGet]
        public ActionResult Index(int? id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}