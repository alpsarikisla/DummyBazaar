using DummyBazaarWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace DummyBazaarWebApp.Areas.AdminPanel.Filters
{
    public class ManagerTypeAuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Manager m = (Manager)filterContext.RequestContext.HttpContext.Session["adminSession"];
            if (m.ManagerType_ID != 1) {
                filterContext.RequestContext.HttpContext.Response.Redirect("~/AdminPanel/YetkiYetersiz/Index");
            }
            base.OnActionExecuted(filterContext);
        }

    }
}