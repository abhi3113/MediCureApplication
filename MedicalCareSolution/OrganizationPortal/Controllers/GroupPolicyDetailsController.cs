using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizationPortal.Controllers
{
    public class GroupPolicyDetailsController : Controller
    {
        // GET: GroupPolicyDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: GroupPolicyDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupPolicyDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupPolicyDetails/Create
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

        // GET: GroupPolicyDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GroupPolicyDetails/Edit/5
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

        // GET: GroupPolicyDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupPolicyDetails/Delete/5
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
