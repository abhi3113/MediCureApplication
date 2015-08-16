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
    public class MaritalStatusController : Controller
    {
        private MemberManagementEntities1 db = new MemberManagementEntities1();

        // GET: MaritalStatus
        public ActionResult Index()
        {
            return View(db.MaritalStatus.ToList());
        }

        // GET: MaritalStatus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatu maritalStatu = db.MaritalStatus.Find(id);
            if (maritalStatu == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatu);
        }

        // GET: MaritalStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaritalStatusId,MaritalStatusCode,MaritalStatusDescription")] MaritalStatu maritalStatu)
        {
            if (ModelState.IsValid)
            {
                db.MaritalStatus.Add(maritalStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maritalStatu);
        }

        // GET: MaritalStatus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatu maritalStatu = db.MaritalStatus.Find(id);
            if (maritalStatu == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatu);
        }

        // POST: MaritalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaritalStatusId,MaritalStatusCode,MaritalStatusDescription")] MaritalStatu maritalStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maritalStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maritalStatu);
        }

        // GET: MaritalStatus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalStatu maritalStatu = db.MaritalStatus.Find(id);
            if (maritalStatu == null)
            {
                return HttpNotFound();
            }
            return View(maritalStatu);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MaritalStatu maritalStatu = db.MaritalStatus.Find(id);
            db.MaritalStatus.Remove(maritalStatu);
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
