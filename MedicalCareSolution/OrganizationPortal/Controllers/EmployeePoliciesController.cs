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
    public class EmployeePoliciesController : Controller
    {
        private MemberManagementEntities1 db = new MemberManagementEntities1();

        // GET: EmployeePolicies
        public ActionResult Index()
        {
            var employeePolicies = db.EmployeePolicies.Include(e => e.Employee).Include(e => e.Enrollment);
            return View(employeePolicies.ToList());
        }

        // GET: EmployeePolicies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePolicy employeePolicy = db.EmployeePolicies.Find(id);
            if (employeePolicy == null)
            {
                return HttpNotFound();
            }
            return View(employeePolicy);
        }

        // GET: EmployeePolicies/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Employee_First_Name");
            ViewBag.EnrollmentTypeId = new SelectList(db.Enrollments, "EnrollmentTypeId", "EnrollmentTypeCode");
            return View();
        }

        // POST: EmployeePolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeePolicyId,EmployeeId,EnrollmentTypeId,HealthPlanId,OrganizationId,DateOfHire,QualifyingEventDate,EffectiveDateOfCoverage")] EmployeePolicy employeePolicy)
        {
            if (ModelState.IsValid)
            {
                db.EmployeePolicies.Add(employeePolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Employee_First_Name", employeePolicy.EmployeeId);
            ViewBag.EnrollmentTypeId = new SelectList(db.Enrollments, "EnrollmentTypeId", "EnrollmentTypeCode", employeePolicy.EnrollmentTypeId);
            return View(employeePolicy);
        }

        // GET: EmployeePolicies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePolicy employeePolicy = db.EmployeePolicies.Find(id);
            if (employeePolicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Employee_First_Name", employeePolicy.EmployeeId);
            ViewBag.EnrollmentTypeId = new SelectList(db.Enrollments, "EnrollmentTypeId", "EnrollmentTypeCode", employeePolicy.EnrollmentTypeId);
            return View(employeePolicy);
        }

        // POST: EmployeePolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeePolicyId,EmployeeId,EnrollmentTypeId,HealthPlanId,OrganizationId,DateOfHire,QualifyingEventDate,EffectiveDateOfCoverage")] EmployeePolicy employeePolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeePolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Employee_First_Name", employeePolicy.EmployeeId);
            ViewBag.EnrollmentTypeId = new SelectList(db.Enrollments, "EnrollmentTypeId", "EnrollmentTypeCode", employeePolicy.EnrollmentTypeId);
            return View(employeePolicy);
        }

        // GET: EmployeePolicies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePolicy employeePolicy = db.EmployeePolicies.Find(id);
            if (employeePolicy == null)
            {
                return HttpNotFound();
            }
            return View(employeePolicy);
        }

        // POST: EmployeePolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeePolicy employeePolicy = db.EmployeePolicies.Find(id);
            db.EmployeePolicies.Remove(employeePolicy);
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
