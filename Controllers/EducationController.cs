using MyCv.Models.Entity;
using MyCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCv.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Educations> repos = new GenericRepository<Educations>();

        // GET: Education
        public ActionResult Index()
        {
            var edu = repos.List();
            return View(edu);
        }
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Educations p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repos.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEdu(int id)
        {
            Educations tx = repos.Find(x => x.ID == id);
            repos.TDelete(tx);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult EditEdu(int id)
        {
            Educations tx = repos.Find(x => x.ID == id);
            return View(tx);
        }

        [HttpPost]
        public ActionResult EditEdu(Educations p)
        {
            Educations tx = repos.Find(x => x.ID == p.ID);
            tx.Title = p.Title;
            tx.Subtitle = p.Subtitle;
            tx.Date = p.Date;
            tx.GPA = p.GPA;
            tx.Subtitle2 = p.Subtitle2;
            repos.TUpdate(tx);
            return RedirectToAction("Index");
        }

    }
}