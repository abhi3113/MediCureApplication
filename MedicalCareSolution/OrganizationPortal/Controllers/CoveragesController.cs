using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrganizationPortal.Models;

namespace OrganizationPortal.Controllers
{
    public class CoveragesController : Controller
    {
        private MemberManagementEntities1 db = new MemberManagementEntities1();

        // GET: Coverages
        public ActionResult Index()
        {
            return View(db.Coverages.ToList());
        }

        // GET: Coverages/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coverage coverage = db.Coverages.Find(id);
            if (coverage == null)
            {
                return HttpNotFound();
            }
            return View(coverage);
        }

        // GET: Coverages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coverages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoverageId,CoverageCode,CoverageDescription")] Coverage coverage)
        {
            if (ModelState.IsValid)
            {
                db.Coverages.Add(coverage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coverage);
        }

        // GET: Coverages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coverage coverage = db.Coverages.Find(id);
            if (coverage == null)
            {
                return HttpNotFound();
            }
            return View(coverage);
        }

        // POST: Coverages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoverageId,CoverageCode,CoverageDescription")] Coverage coverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coverage);
        }

        // GET: Coverages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coverage coverage = db.Coverages.Find(id);
            if (coverage == null)
            {
                return HttpNotFound();
            }
            return View(coverage);
        }

        // POST: Coverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Coverage coverage = db.Coverages.Find(id);
            db.Coverages.Remove(coverage);
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
    }
}
