﻿using DummyBazaarWebApp.Areas.AdminPanel.Filters;
using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyBazaarWebApp.Areas.AdminPanel.Controllers
{
    [AdminAuthenticationFilter]
    public class CategoryController : Controller
    {
        DummyBazaarModel db = new DummyBazaarModel();
        // GET: AdminPanel/Category
       
        public ActionResult Index()
        {
            return View(db.Categories.OrderBy(s=> s.TopCategory_ID).ToList());
        }

        [HttpGet]
        [ManagerTypeAuthenticationFilter]
        public ActionResult Create()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "Üst Kategori", Value = "0", Selected = true });
            foreach (Category item in db.Categories.Where(s=> s.TopCategory_ID == null))
            {
                categories.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString(), Selected = false });
            }
            ViewBag.TopCategories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                if (model.TopCategory_ID == 0)
                {
                    model.TopCategory_ID = null;
                }

                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Category c = db.Categories.Find(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Mesaj = "Düzenleme İşlemi Başarılı";
                }
                catch
                {
                    ViewBag.Mesaj = "Kategori Düzenlenirken Bir Hata Oluştu";
                }
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id !=  null)
            {
                Category c = db.Categories.Find(id);
                db.Categories.Remove(c);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}