using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;

namespace MyCv.Controllers
{
    public class DefaultController : Controller
    {
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var values = db.About.ToList();

            return View(values);
        }

        public PartialViewResult Experiences()
        {
            var experiences = db.Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult SocialMedia()
        {
            var sm = db.SocialMedia.ToList();
            return PartialView(sm);
        }
        public PartialViewResult Education()
        {
            var educations = db.Educations.ToList();

            return PartialView(educations);
        }

        public PartialViewResult Skills()
        {
            var skills = db.Skills.ToList();

            return PartialView(skills);
        }

        public PartialViewResult Interests()
        {
            var interest = db.Interests.ToList();

            return PartialView(interest);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
          return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact x)
        {
            x.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(x);
            db.SaveChanges();
             return PartialView();
        }
    }
}