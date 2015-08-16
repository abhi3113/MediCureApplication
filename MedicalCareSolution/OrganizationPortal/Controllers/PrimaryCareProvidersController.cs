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
    public class PrimaryCareProvidersController : Controller
    {
        private MemberManagementEntities1 db = new MemberManagementEntities1();

        // GET: PrimaryCareProviders
        public ActionResult Index()
        {
            var primaryCareProviders = db.PrimaryCareProviders.Include(p => p.Address);
            return View(primaryCareProviders.ToList());
        }

        // GET: PrimaryCareProviders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryCareProvider primaryCareProvider = db.PrimaryCareProviders.Find(id);
            if (primaryCareProvider == null)
            {
                return HttpNotFound();
            }
            return View(primaryCareProvider);
        }

        // GET: PrimaryCareProviders/Create
        public ActionResult Create()
        {
            ViewBag.PrimaryCareProviderAddressId = new SelectList(db.Addresses, "AddressId", "Address_Street1");
            return View();
        }

        // POST: PrimaryCareProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrimaryCareProviderId,PrimaryCareProviderFirstName,PrimaryCareProviderLastName,PrimaryCareProviderAddressId")] PrimaryCareProvider primaryCareProvider)
        {
            if (ModelState.IsValid)
            {
                db.PrimaryCareProviders.Add(primaryCareProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrimaryCareProviderAddressId = new SelectList(db.Addresses, "AddressId", "Address_Street1", primaryCareProvider.PrimaryCareProviderAddressId);
            return View(primaryCareProvider);
        }

        // GET: PrimaryCareProviders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryCareProvider primaryCareProvider = db.PrimaryCareProviders.Find(id);
            if (primaryCareProvider == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrimaryCareProviderAddressId = new SelectList(db.Addresses, "AddressId", "Address_Street1", primaryCareProvider.PrimaryCareProviderAddressId);
            return View(primaryCareProvider);
        }

        // POST: PrimaryCareProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrimaryCareProviderId,PrimaryCareProviderFirstName,PrimaryCareProviderLastName,PrimaryCareProviderAddressId")] PrimaryCareProvider primaryCareProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primaryCareProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrimaryCareProviderAddressId = new SelectList(db.Addresses, "AddressId", "Address_Street1", primaryCareProvider.PrimaryCareProviderAddressId);
            return View(primaryCareProvider);
        }

        // GET: PrimaryCareProviders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimaryCareProvider primaryCareProvider = db.PrimaryCareProviders.Find(id);
            if (primaryCareProvider == null)
            {
                return HttpNotFound();
            }
            return View(primaryCareProvider);
        }

        // POST: PrimaryCareProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PrimaryCareProvider primaryCareProvider = db.PrimaryCareProviders.Find(id);
            db.PrimaryCareProviders.Remove(primaryCareProvider);
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
