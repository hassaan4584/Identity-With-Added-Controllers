using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class DirectorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Director
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Purchaserequests()
        {
            return View(db.PurchaseRequests.ToList());
        }


        public ActionResult Meetings()
        {
            return View(db.Meetings.ToList());
        }


    }
}