using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Controllers
{
    public class HomeController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.Where(x=> x.IsActive == true).ToList());
        }
    }
}