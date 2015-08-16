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
    public class EmployeesController : Controller
    {
        private MemberManagementEntities1 db = new MemberManagementEntities1();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Address).Include(e => e.Coverage).Include(e => e.MaritalStatu).Include(e => e.PrimaryCareProvider);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Address_Id = new SelectList(db.Addresses, "AddressId", "Address_Street1");
            ViewBag.Coverage_Id = new SelectList(db.Coverages, "CoverageId", "CoverageCode");
            ViewBag.Marital_Status_id = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusCode");
            ViewBag.Primary_Care_Id = new SelectList(db.PrimaryCareProviders, "PrimaryCareProviderId", "PrimaryCareProviderFirstName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Employee_First_Name,Employee_Last_Name,Employee_Middle_Name,Employee_SSN,Employee_DOB,Eomployee_Gender,Employee_Address_Id,Marital_Status_id,Coverage_Id,Primary_Care_Id,PCP")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Address_Id = new SelectList(db.Addresses, "AddressId", "Address_Street1", employee.Employee_Address_Id);
            ViewBag.Coverage_Id = new SelectList(db.Coverages, "CoverageId", "CoverageCode", employee.Coverage_Id);
            ViewBag.Marital_Status_id = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusCode", employee.Marital_Status_id);
            ViewBag.Primary_Care_Id = new SelectList(db.PrimaryCareProviders, "PrimaryCareProviderId", "PrimaryCareProviderFirstName", employee.Primary_Care_Id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Address_Id = new SelectList(db.Addresses, "AddressId", "Address_Street1", employee.Employee_Address_Id);
            ViewBag.Coverage_Id = new SelectList(db.Coverages, "CoverageId", "CoverageCode", employee.Coverage_Id);
            ViewBag.Marital_Status_id = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusCode", employee.Marital_Status_id);
            ViewBag.Primary_Care_Id = new SelectList(db.PrimaryCareProviders, "PrimaryCareProviderId", "PrimaryCareProviderFirstName", employee.Primary_Care_Id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Employee_First_Name,Employee_Last_Name,Employee_Middle_Name,Employee_SSN,Employee_DOB,Eomployee_Gender,Employee_Address_Id,Marital_Status_id,Coverage_Id,Primary_Care_Id,PCP")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Address_Id = new SelectList(db.Addresses, "AddressId", "Address_Street1", employee.Employee_Address_Id);
            ViewBag.Coverage_Id = new SelectList(db.Coverages, "CoverageId", "CoverageCode", employee.Coverage_Id);
            ViewBag.Marital_Status_id = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusCode", employee.Marital_Status_id);
            ViewBag.Primary_Care_Id = new SelectList(db.PrimaryCareProviders, "PrimaryCareProviderId", "PrimaryCareProviderFirstName", employee.Primary_Care_Id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
