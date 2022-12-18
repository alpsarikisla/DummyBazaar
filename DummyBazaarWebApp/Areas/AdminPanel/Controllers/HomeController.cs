using DummyBazaarWebApp.Areas.AdminPanel.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Areas.AdminPanel.Controllers
{
    [AdminAuthenticationFilter]
    public class HomeController : Controller
    {
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}