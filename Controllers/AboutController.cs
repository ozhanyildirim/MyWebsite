using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repositories;
namespace MyCv.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<About> repos = new GenericRepository<About>();
        // GET: Interest
        [HttpGet]
        public ActionResult Index()
        {
            var abt = repos.List();
            return View(abt);
        }
        
         [HttpPost]
        public ActionResult Index(About p)
        {
            About ab = repos.Find(x => x.ID == 1);
            ab.Name = p.Name;
            ab.Surname = p.Surname;
            ab.Phone = p.Phone;
            ab.Image = p.Image;
            ab.Adress = p.Adress;
            ab.Email = p.Email;
            ab.Explanation = p.Explanation;

            repos.TUpdate(ab);
            return RedirectToAction("Index");
        }
    }
}