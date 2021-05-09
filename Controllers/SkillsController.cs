using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repositories;

namespace MyCv.Controllers
{
    public class SkillsController : Controller
    {
        GenericRepository<Skills> repos = new GenericRepository<Skills>();
        // GET: Skills
        public ActionResult Index()
        {
            var skills = repos.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkill(Skills s)
        {
            repos.TAdd(s);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            Skills ds = repos.Find(x => x.ID == id);
            repos.TDelete(ds);
            return RedirectToAction("Index");
        }

        public ActionResult EditSkill(int id)
        {
            Skills ds = repos.Find(x => x.ID == id);
            return View(ds);
        }

        [HttpPost]
        public ActionResult EditSkill(Skills p)
        {
            Skills ds = repos.Find(x => x.ID == p.ID);
            ds.Skills1 = p.Skills1;
            ds.Progress = p.Progress;
            repos.TUpdate(ds);
            return RedirectToAction("Index");
        }
    }
}