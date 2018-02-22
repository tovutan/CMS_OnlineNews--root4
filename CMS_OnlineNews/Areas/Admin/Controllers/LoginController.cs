using Model.Dao;
using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_OnlineNews.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
    
        // GET: Admin/User

        [HttpGet]
        public ActionResult dangnhap()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult dangnhap(User model)
        //{
           
        //        var kq = new UserDao();
        //        int result = kq.Login(model.UserName, model.PasswordHash);
        //        if (result == 1)
        //        {
        //            var user = new User();
        //            Session["user"] = user;
        //            return RedirectToAction("List", "Post");
        //        }
        //        else
        //        {
        //            if (result == -1)
        //            {
        //                ModelState.AddModelError("", "Tài khoản đang bị khóa");
        //            }
        //        }
           
        //    return View("dangnhap");
        //}
    }
}