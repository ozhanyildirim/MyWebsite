using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCv.Models.Entity;
using MyCv.Repositories;


namespace MyCv.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repos = new GenericRepository<SocialMedia>();

        // GET: SocialMedia
        public ActionResult Index()
        {
            var social = repos.List();
            return View(social);
        }
        [HttpGet]
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(SocialMedia s)
        {
            repos.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Find(int id)
        {
            var acc = repos.Find(x => x.ID == id);
                return View(acc);
        }
        [HttpPost]
        public ActionResult Find(SocialMedia sm)
        {
            var acc = repos.Find(x => x.ID == sm.ID);
            acc.Name = sm.Name;
            acc.Link = sm.Link;
            acc.Icon = sm.Icon;
            repos.TUpdate(acc);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            SocialMedia ds = repos.Find(x => x.ID == id);
            repos.TDelete(ds);
            return RedirectToAction("Index");
        }
    }
}