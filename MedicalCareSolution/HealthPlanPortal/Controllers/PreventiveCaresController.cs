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
    public class PreventiveCaresController : Controller
    {
        private HealthPlanDBEntities db = new HealthPlanDBEntities();

        // GET: PreventiveCares
        public async Task<ActionResult> Index()
        {
            return View(await db.PreventiveCares.ToListAsync());
        }

        // GET: PreventiveCares/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreventiveCare preventiveCare = await db.PreventiveCares.FindAsync(id);
            if (preventiveCare == null)
            {
                return HttpNotFound();
            }
            return View(preventiveCare);
        }

        // GET: PreventiveCares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreventiveCares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PreventiveCareId,PhysicalExamLimit,RoutinePediatricCareLimit,ImmunizationLimit")] PreventiveCare preventiveCare)
        {
            if (ModelState.IsValid)
            {
                db.PreventiveCares.Add(preventiveCare);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(preventiveCare);
        }

        // GET: PreventiveCares/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreventiveCare preventiveCare = await db.PreventiveCares.FindAsync(id);
            if (preventiveCare == null)
            {
                return HttpNotFound();
            }
            return View(preventiveCare);
        }

        // POST: PreventiveCares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PreventiveCareId,PhysicalExamLimit,RoutinePediatricCareLimit,ImmunizationLimit")] PreventiveCare preventiveCare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preventiveCare).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(preventiveCare);
        }

        // GET: PreventiveCares/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreventiveCare preventiveCare = await db.PreventiveCares.FindAsync(id);
            if (preventiveCare == null)
            {
                return HttpNotFound();
            }
            return View(preventiveCare);
        }

        // POST: PreventiveCares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PreventiveCare preventiveCare = await db.PreventiveCares.FindAsync(id);
            db.PreventiveCares.Remove(preventiveCare);
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
