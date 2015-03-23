using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Identity.Models;

namespace Identity.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teacher
        public ActionResult Index()
        {
            return View(db.DemandItems.ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandItem demandItem = db.DemandItems.Find(id);
            if (demandItem == null)
            {
                return HttpNotFound();
            }
            return View(demandItem);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DemandID,ItemName,Quantity,Issued_by,Issue_Date,current_status,Price")] DemandItem demandItem)
        {
            if (ModelState.IsValid)
            {
                demandItem.Issue_Date = DateTime.Now;
                            //demandItem.Price = 125;
                demandItem.current_status = "pending";
                demandItem.Issued_by = this.User.Identity.Name;
//                db.DemandItems.Add(demandItem);
//                db.SaveChanges();
                db.DemandItems.Add(demandItem);
                db.SaveChanges();
                return View();
//                return RedirectToAction("Index");
            }

            return View(demandItem);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandItem demandItem = db.DemandItems.Find(id);
            if (demandItem == null)
            {
                return HttpNotFound();
            }
            return View(demandItem);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DemandID,ItemName,Quantity,Issued_by,Issue_Date,current_status,Price")] DemandItem demandItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demandItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demandItem);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandItem demandItem = db.DemandItems.Find(id);
            if (demandItem == null)
            {
                return HttpNotFound();
            }
            return View(demandItem);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemandItem demandItem = db.DemandItems.Find(id);
            db.DemandItems.Remove(demandItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Status()
        {
            /////// SOME ERROR HERE

            List<DemandItem> query = new List<DemandItem>();
            //query = (from demands in db.DemandItems
            //         where demands.current_status == "pending"
            //         select demands).ToList();

            foreach (var result in db.DemandItems)
            {
                if(result.current_status == "pending")
                    query.Add(result);
            }

            //var model = new List<DemandItem>();
            //foreach (var q in query)
            //{

            //    model = db.DemandItems.ToList();

            //}
            return View(query.ToList());
            //return View();

        }
    }
}
