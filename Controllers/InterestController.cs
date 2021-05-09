using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repositories;

namespace MyCv.Controllers
{
    public class InterestController : Controller
    {
        GenericRepository<Interests> repos = new GenericRepository<Interests>();
        // GET: Interest
        [HttpGet]
        public ActionResult Index()
        {
            var intr = repos.List();     
            return View(intr);
        }
        [HttpPost]
        public ActionResult Index(Interests x)
        {
            var i = repos.Find(a => a.ID == 1); 
            i.Description = x.Description;
            i.Description2 = x.Description2;
            repos.TUpdate(i);
            return RedirectToAction("Index");
        }
    }
}