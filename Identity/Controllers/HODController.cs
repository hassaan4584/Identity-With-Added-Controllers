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
    public class HODController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HOD
        public ActionResult Index()
        {
            return View(db.DemandItems.ToList());
        }

        // GET: HOD/Details/5
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

        // GET: HOD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DemandID,ItemName,Quantity,Issued_by,Issue_Date,current_status,Price")] DemandItem demandItem)
        {
            if (ModelState.IsValid)
            {
                db.DemandItems.Add(demandItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demandItem);
        }

        // GET: HOD/Edit/5
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

        // POST: HOD/Edit/5
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

        // GET: HOD/Delete/5
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

        // POST: HOD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemandItem demandItem = db.DemandItems.Find(id);
            db.DemandItems.Remove(demandItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PurchaseRequests()
        {

            return View(db.PurchaseRequests.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
