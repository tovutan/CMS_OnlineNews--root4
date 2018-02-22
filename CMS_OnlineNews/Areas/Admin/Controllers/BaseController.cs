
using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS_OnlineNews.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (User)Session["user"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Login", action = "dangnhap", area = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }
       
    }
}