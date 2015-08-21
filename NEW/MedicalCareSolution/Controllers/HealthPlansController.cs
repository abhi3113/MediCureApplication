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
    public class HealthPlansController : Controller
    {
        private HealthPlanDatabaseEntities db = new HealthPlanDatabaseEntities();

        // GET: HealthPlans
        public ActionResult Index()
        {
            return View(db.HealthPlans.ToList());
        }

        // GET: HealthPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthPlan healthPlan = db.HealthPlans.Find(id);
            if (healthPlan == null)
            {
                return HttpNotFound();
            }
            return View(healthPlan);
        }

        // GET: HealthPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HealthPlanId,HealthPlanCode,HealthPlanDescription,PCPrequiredBool,PCPNetworkBool")] HealthPlan healthPlan)
        {
            if (ModelState.IsValid)
            {
                db.HealthPlans.Add(healthPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healthPlan);
        }

        // GET: HealthPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthPlan healthPlan = db.HealthPlans.Find(id);
            if (healthPlan == null)
            {
                return HttpNotFound();
            }
            return View(healthPlan);
        }

        // POST: HealthPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HealthPlanId,HealthPlanCode,HealthPlanDescription,PCPrequiredBool,PCPNetworkBool")] HealthPlan healthPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthPlan);
        }

        // GET: HealthPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthPlan healthPlan = db.HealthPlans.Find(id);
            if (healthPlan == null)
            {
                return HttpNotFound();
            }
            return View(healthPlan);
        }

        // POST: HealthPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthPlan healthPlan = db.HealthPlans.Find(id);
            db.HealthPlans.Remove(healthPlan);
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
