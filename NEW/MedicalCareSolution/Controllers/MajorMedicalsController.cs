using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthPlanPortal.Models;

namespace HealthPlanPortal.Controllers
{
    public class MajorMedicalsController : Controller
    {
        private HealthPlanDatabaseEntities db = new HealthPlanDatabaseEntities();

        // GET: MajorMedicals
        public ActionResult Index()
        {
            var majorMedicals = db.MajorMedicals.Include(m => m.HealthPlan);
            return View(majorMedicals.ToList());
        }

        // GET: MajorMedicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorMedical majorMedical = db.MajorMedicals.Find(id);
            if (majorMedical == null)
            {
                return HttpNotFound();
            }
            return View(majorMedical);
        }

        // GET: MajorMedicals/Create
        public ActionResult Create()
        {
            ViewBag.HealthPlanId = new SelectList(db.HealthPlans, "HealthPlanId", "HealthPlanCode");
            return View();
        }

        // POST: MajorMedicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MajorMedicalId,MajorMedicalProvideListBool,MajorMedicalDescription,HealthPlanId")] MajorMedical majorMedical)
        {
            if (ModelState.IsValid)
            {
                db.MajorMedicals.Add(majorMedical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HealthPlanId = new SelectList(db.HealthPlans, "HealthPlanId", "HealthPlanCode", majorMedical.HealthPlanId);
            return View(majorMedical);
        }

        // GET: MajorMedicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorMedical majorMedical = db.MajorMedicals.Find(id);
            if (majorMedical == null)
            {
                return HttpNotFound();
            }
            ViewBag.HealthPlanId = new SelectList(db.HealthPlans, "HealthPlanId", "HealthPlanCode", majorMedical.HealthPlanId);
            return View(majorMedical);
        }

        // POST: MajorMedicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MajorMedicalId,MajorMedicalProvideListBool,MajorMedicalDescription,HealthPlanId")] MajorMedical majorMedical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majorMedical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HealthPlanId = new SelectList(db.HealthPlans, "HealthPlanId", "HealthPlanCode", majorMedical.HealthPlanId);
            return View(majorMedical);
        }

        // GET: MajorMedicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorMedical majorMedical = db.MajorMedicals.Find(id);
            if (majorMedical == null)
            {
                return HttpNotFound();
            }
            return View(majorMedical);
        }

        // POST: MajorMedicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MajorMedical majorMedical = db.MajorMedicals.Find(id);
            db.MajorMedicals.Remove(majorMedical);
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
