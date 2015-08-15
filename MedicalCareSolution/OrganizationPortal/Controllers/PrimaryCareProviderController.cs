using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizationPortal.Controllers
{
    public class PrimaryCareProviderController : Controller
    {
        // GET: PrimaryCareProvider
        public ActionResult Index()
        {
            return View();
        }

        // GET: PrimaryCareProvider/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrimaryCareProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrimaryCareProvider/Create
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

        // GET: PrimaryCareProvider/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrimaryCareProvider/Edit/5
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

        // GET: PrimaryCareProvider/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrimaryCareProvider/Delete/5
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
