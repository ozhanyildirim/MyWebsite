using MyCv.Models.Entity;
using MyCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCv.Controllers
{
    public class ContactController : Controller
    {

        GenericRepository<Contact> repos = new GenericRepository<Contact>();

        // GET: Contact
        public ActionResult Index()
        {
            var messages = repos.List();
            return View(messages);
        }
    }
}