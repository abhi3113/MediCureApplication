﻿using System;
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
    public class GroupPolicyDetailsController : Controller
    {
        private MemberManagementEntities1 db = new MemberManagementEntities1();

        // GET: GroupPolicyDetails
        public ActionResult Index()
        {
            return View(db.GroupPolicyDetails.ToList());
        }

        // GET: GroupPolicyDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPolicyDetail groupPolicyDetail = db.GroupPolicyDetails.Find(id);
            if (groupPolicyDetail == null)
            {
                return HttpNotFound();
            }
            return View(groupPolicyDetail);
        }

        // GET: GroupPolicyDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupPolicyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupPolicyId,GroupNumber,GroupDetails,OrganizationId")] GroupPolicyDetail groupPolicyDetail)
        {
            if (ModelState.IsValid)
            {
                db.GroupPolicyDetails.Add(groupPolicyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupPolicyDetail);
        }

        // GET: GroupPolicyDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPolicyDetail groupPolicyDetail = db.GroupPolicyDetails.Find(id);
            if (groupPolicyDetail == null)
            {
                return HttpNotFound();
            }
            return View(groupPolicyDetail);
        }

        // POST: GroupPolicyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupPolicyId,GroupNumber,GroupDetails,OrganizationId")] GroupPolicyDetail groupPolicyDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupPolicyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupPolicyDetail);
        }

        // GET: GroupPolicyDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPolicyDetail groupPolicyDetail = db.GroupPolicyDetails.Find(id);
            if (groupPolicyDetail == null)
            {
                return HttpNotFound();
            }
            return View(groupPolicyDetail);
        }

        // POST: GroupPolicyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GroupPolicyDetail groupPolicyDetail = db.GroupPolicyDetails.Find(id);
            db.GroupPolicyDetails.Remove(groupPolicyDetail);
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
