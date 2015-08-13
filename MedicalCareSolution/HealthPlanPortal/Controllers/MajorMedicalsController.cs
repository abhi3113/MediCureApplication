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
    public class MajorMedicalsController : Controller
    {
        private HealthPlanDBEntities db = new HealthPlanDBEntities();

        // GET: MajorMedicals
        public async Task<ActionResult> Index()
        {
            return View(await db.MajorMedicals.ToListAsync());
        }

        // GET: MajorMedicals/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorMedical majorMedical = await db.MajorMedicals.FindAsync(id);
            if (majorMedical == null)
            {
                return HttpNotFound();
            }
            return View(majorMedical);
        }

        // GET: MajorMedicals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MajorMedicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MajorMedicalId,MajorMedicalProvideListBool,MajorMedicalDescription")] MajorMedical majorMedical)
        {
            if (ModelState.IsValid)
            {
                db.MajorMedicals.Add(majorMedical);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(majorMedical);
        }

        // GET: MajorMedicals/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorMedical majorMedical = await db.MajorMedicals.FindAsync(id);
            if (majorMedical == null)
            {
                return HttpNotFound();
            }
            return View(majorMedical);
        }

        // POST: MajorMedicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MajorMedicalId,MajorMedicalProvideListBool,MajorMedicalDescription")] MajorMedical majorMedical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majorMedical).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(majorMedical);
        }

        // GET: MajorMedicals/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorMedical majorMedical = await db.MajorMedicals.FindAsync(id);
            if (majorMedical == null)
            {
                return HttpNotFound();
            }
            return View(majorMedical);
        }

        // POST: MajorMedicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MajorMedical majorMedical = await db.MajorMedicals.FindAsync(id);
            db.MajorMedicals.Remove(majorMedical);
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
