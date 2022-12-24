using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();
        // GET: AdminPanel/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string mail, string password)
        {
            if (ModelState.IsValid)
            {
                int sayi = db.Managers.Count(s => s.Mail == mail && s.Password == password);
                if (sayi > 0)
                {
                    Manager m = db.Managers.First(s => s.Mail == mail && s.Password == password);
                    if (m.IsActive)
                    {
                        Session["adminSession"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.message = "Kullanıcı aktif değil";
                    }
                }
                else
                {
                    ViewBag.message = "Kullanıcı bulunamadı";
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session["adminSession"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}