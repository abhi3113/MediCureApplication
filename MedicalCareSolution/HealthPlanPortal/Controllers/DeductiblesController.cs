﻿using System;
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
    public class DeductiblesController : Controller
    {
        private HealthPlanDBEntities db = new HealthPlanDBEntities();

        // GET: Deductibles
        public async Task<ActionResult> Index()
        {
            return View(await db.Deductibles.ToListAsync());
        }

        // GET: Deductibles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deductible deductible = await db.Deductibles.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "DeductibleId,DeductibleCode,IndividualDedAmt,FamilyDedAmt,MaxDeductibleAmountPerIndividual,ServicesCoveredBeforeDeductibleMetBool,DeductibleIncdInOutOfPcktBool,AnnualLimitsPlanBool,AnnualPremium,CoinsuranceUpper,CoinsuranceLower,AnnualLimitHigher,AnnualLimitLower,TotalEstimatedCost")] Deductible deductible)
        {
            if (ModelState.IsValid)
            {
                db.Deductibles.Add(deductible);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(deductible);
        }

        // GET: Deductibles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deductible deductible = await db.Deductibles.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "DeductibleId,DeductibleCode,IndividualDedAmt,FamilyDedAmt,MaxDeductibleAmountPerIndividual,ServicesCoveredBeforeDeductibleMetBool,DeductibleIncdInOutOfPcktBool,AnnualLimitsPlanBool,AnnualPremium,CoinsuranceUpper,CoinsuranceLower,AnnualLimitHigher,AnnualLimitLower,TotalEstimatedCost")] Deductible deductible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deductible).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(deductible);
        }

        // GET: Deductibles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deductible deductible = await db.Deductibles.FindAsync(id);
            if (deductible == null)
            {
                return HttpNotFound();
            }
            return View(deductible);
        }

        // POST: Deductibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Deductible deductible = await db.Deductibles.FindAsync(id);
            db.Deductibles.Remove(deductible);
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