using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finaldesign_template.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Teacher/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Prepare_Purchase_requisition()
        {
            return View();
        }

        [Authorize]
        public ActionResult store()
        {
            DemandItem d = new DemandItem();
            d.Issue_Date = DateTime.Now;
            //            d.Price = 125;
            d.current_status = "pending";
            d.Issued_by = this.User.Identity.Name;
            db.DemandItems.Add(d);
            db.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult store(DemandItem d)
        {
            d.Issue_Date = DateTime.Now;
//            d.Price = 125;
            d.current_status = "pending";
            d.Issued_by = this.User.Identity.Name;
            db.DemandItems.Add(d);
            db.SaveChanges();
            return View();

        }

        public ActionResult MyProfile()
        {
            return View();
        }
        public void logoutClick(object sender, EventArgs e)
        {
            this.Session.Abandon();
            Session.Clear();
            this.Response.Redirect("index");
        }

	}
}