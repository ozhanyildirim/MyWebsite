using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repositories;

namespace MyCv.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repos = new ExperienceRepository();
        // GET: Experience
        public ActionResult Index()
        {
            var exp = repos.List();
            return View(exp);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experiences p)
        {
            repos.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExp(int id)
        {
            Experiences tx = repos.Find(x => x.ID == id); 
                   repos.TDelete(tx);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult FindExp(int id)
        {
            Experiences tx = repos.Find(x => x.ID == id);
            return View(tx);
        }

        [HttpPost]
        public ActionResult FindExp(Experiences p)
        {
            Experiences tx = repos.Find(x => x.ID == p.ID);
            tx.Title = p.Title;
            tx.Subtitle = p.Subtitle;
            tx.Date = p.Date;
            tx.Explanation = p.Explanation;
            repos.TUpdate(tx);
            return RedirectToAction("Index");
        }

    }
}