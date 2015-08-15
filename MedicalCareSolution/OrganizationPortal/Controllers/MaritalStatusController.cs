using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizationPortal.Controllers
{
    public class MaritalStatusController : Controller
    {
        // GET: MaritalStatus
        public ActionResult Index()
        {
            return View();
        }

        // GET: MaritalStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaritalStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MaritalStatus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MaritalStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MaritalStatus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
