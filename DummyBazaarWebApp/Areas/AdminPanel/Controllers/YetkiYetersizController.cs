﻿using DummyBazaarWebApp.Areas.AdminPanel.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Areas.AdminPanel.Controllers
{
    [AdminAuthenticationFilter]
    public class YetkiYetersizController : Controller
    {
        // GET: AdminPanel/YetkiYetersiz
        public ActionResult Index()
        {
            return View();
        }
    }
}