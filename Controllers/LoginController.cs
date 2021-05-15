using MyCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCv.Controllers
{   
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            DbCVEntities db = new DbCVEntities();
            var root = db.Admin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if(root != null)
            {
                FormsAuthentication.SetAuthCookie(root.UserName, false);
                Session["UserName"] = root.UserName.ToString();
                return RedirectToAction("Index", "Experience");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}