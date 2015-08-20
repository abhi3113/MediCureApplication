using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthPlanPortal.Models;
using PagedList;

namespace HealthPlanPortal.Controllers
{
    public class HealthPlansController : Controller
    {
        private HealthPlanDBEntities db = new HealthPlanDBEntities();

        // GET: HealthPlans
        //public ViewResult Index()
        //{

        //    return View(db.HealthPlans.ToList());
        //}
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //return View(db.HealthPlans.ToList());

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var HealthPlan = from s in db.HealthPlans
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                HealthPlan = HealthPlan.Where(s => s.HealthPlanCode.Contains(searchString)
                                       || s.HealthPlanCode.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    HealthPlan = HealthPlan.OrderByDescending(s => s.HealthPlanCode);
                    break;

                default:  // Name ascending 
                    HealthPlan = HealthPlan.OrderBy(s => s.HealthPlanCode);
                    break;
            }

            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            return View(HealthPlan);
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
