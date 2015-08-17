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
    public class DeductiblesController : Controller
    {
        private HealthPlanDBEntities db = new HealthPlanDBEntities();

        // GET: Deductibles
        public ActionResult Index()
        {
            return View(db.Deductibles.ToList());
        }

        // GET: Deductibles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deductible deductible = db.Deductibles.Find(id);
            if (deductible == null)
            {
                return HttpNotFound();
            }
            return View(deductible);
        }

        // GET: Deductibles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deductibles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeductibleId,DeductibleCode,IndividualDedAmt,FamilyDedAmt,MaxDeductibleAmountPerIndividual,ServicesCoveredBeforeDeductibleMetBool,DeductibleIncdInOutOfPcktBool,AnnualLimitsPlanBool,AnnualPremium,CoinsuranceUpper,CoinsuranceLower,AnnualLimitHigher,AnnualLimitLower,TotalEstimatedCost")] Deductible deductible)
        {
            if (ModelState.IsValid)
            {
                db.Deductibles.Add(deductible);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deductible);
        }

        // GET: Deductibles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deductible deductible = db.Deductibles.Find(id);
            if (deductible == null)
            {
                return HttpNotFound();
            }
            return View(deductible);
        }

        // POST: Deductibles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeductibleId,DeductibleCode,IndividualDedAmt,FamilyDedAmt,MaxDeductibleAmountPerIndividual,ServicesCoveredBeforeDeductibleMetBool,DeductibleIncdInOutOfPcktBool,AnnualLimitsPlanBool,AnnualPremium,CoinsuranceUpper,CoinsuranceLower,AnnualLimitHigher,AnnualLimitLower,TotalEstimatedCost")] Deductible deductible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deductible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deductible);
        }

        // GET: Deductibles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deductible deductible = db.Deductibles.Find(id);
            if (deductible == null)
            {
                return HttpNotFound();
            }
            return View(deductible);
        }

        // POST: Deductibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deductible deductible = db.Deductibles.Find(id);
            db.Deductibles.Remove(deductible);
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
