using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repositories;

namespace MyCv.Controllers
{
    
    public class AdminController : Controller
    {
        GenericRepository<Admin> repos = new GenericRepository<Admin>();
        // GET: Admin
        public ActionResult Index()
        {
            var list = repos.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            repos.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            Admin tx = repos.Find(x => x.ID == id);
            repos.TDelete(tx);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            Admin tx = repos.Find(x => x.ID == id);
            return View(tx);
        }

        [HttpPost]
        public ActionResult AdminEdit(Admin p)
        {
            Admin tx = repos.Find(x => x.ID == p.ID);
            tx.UserName = p.UserName;
            tx.Password = p.Password;
            
            repos.TUpdate(tx);
            return RedirectToAction("Index");
        }
    }
}