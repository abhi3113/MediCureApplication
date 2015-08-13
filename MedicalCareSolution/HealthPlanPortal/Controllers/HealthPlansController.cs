using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthPlanPortal.Models;

namespace HealthPlanPortal.Controllers
{
    public class HealthPlansController : Controller
    {
        private HealthPlanDBEntities db = new HealthPlanDBEntities();

        // GET: HealthPlans
        public async Task<ActionResult> Index()
        {
            var healthPlans = db.HealthPlans.Include(h => h.Deductible).Include(h => h.MajorMedical).Include(h => h.PreventiveCare);
            return View(await healthPlans.ToListAsync());
        }

        // GET: HealthPlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthPlan healthPlan = await db.HealthPlans.FindAsync(id);
            if (healthPlan == null)
            {
                return HttpNotFound();
            }
            return View(healthPlan);
        }

        // GET: HealthPlans/Create
        public ActionResult Create()
        {
            ViewBag.DeductibleId = new SelectList(db.Deductibles, "DeductibleId", "DeductibleCode");
            ViewBag.MajorMedicalId = new SelectList(db.MajorMedicals, "MajorMedicalId", "MajorMedicalDescription");
            ViewBag.PreventiveCareId = new SelectList(db.PreventiveCares, "PreventiveCareId", "PreventiveCareId");
            return View();
        }

        // POST: HealthPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HealthPlanId,HealthPlanCode,HealthPlanDescription,DeductibleId,PreventiveCareId,MajorMedicalId,PCPrequiredBool,PCPNetworkBool")] HealthPlan healthPlan)
        {
            if (ModelState.IsValid)
            {
                db.HealthPlans.Add(healthPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DeductibleId = new SelectList(db.Deductibles, "DeductibleId", "DeductibleCode", healthPlan.DeductibleId);
            ViewBag.MajorMedicalId = new SelectList(db.MajorMedicals, "MajorMedicalId", "MajorMedicalDescription", healthPlan.MajorMedicalId);
            ViewBag.PreventiveCareId = new SelectList(db.PreventiveCares, "PreventiveCareId", "PreventiveCareId", healthPlan.PreventiveCareId);
            return View(healthPlan);
        }

        // GET: HealthPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthPlan healthPlan = await db.HealthPlans.FindAsync(id);
            if (healthPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeductibleId = new SelectList(db.Deductibles, "DeductibleId", "DeductibleCode", healthPlan.DeductibleId);
            ViewBag.MajorMedicalId = new SelectList(db.MajorMedicals, "MajorMedicalId", "MajorMedicalDescription", healthPlan.MajorMedicalId);
            ViewBag.PreventiveCareId = new SelectList(db.PreventiveCares, "PreventiveCareId", "PreventiveCareId", healthPlan.PreventiveCareId);
            return View(healthPlan);
        }

        // POST: HealthPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HealthPlanId,HealthPlanCode,HealthPlanDescription,DeductibleId,PreventiveCareId,MajorMedicalId,PCPrequiredBool,PCPNetworkBool")] HealthPlan healthPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DeductibleId = new SelectList(db.Deductibles, "DeductibleId", "DeductibleCode", healthPlan.DeductibleId);
            ViewBag.MajorMedicalId = new SelectList(db.MajorMedicals, "MajorMedicalId", "MajorMedicalDescription", healthPlan.MajorMedicalId);
            ViewBag.PreventiveCareId = new SelectList(db.PreventiveCares, "PreventiveCareId", "PreventiveCareId", healthPlan.PreventiveCareId);
            return View(healthPlan);
        }

        // GET: HealthPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthPlan healthPlan = await db.HealthPlans.FindAsync(id);
            if (healthPlan == null)
            {
                return HttpNotFound();
            }
            return View(healthPlan);
        }

        // POST: HealthPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HealthPlan healthPlan = await db.HealthPlans.FindAsync(id);
            db.HealthPlans.Remove(healthPlan);
            await db.SaveChangesAsync();
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
