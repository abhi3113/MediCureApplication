using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthPlanPortal.Models;

namespace HealthPlanPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LoggedUserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Medical Care Application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Medical Care Application contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser u)
        {
            if (ModelState.IsValid) // this is check validity
            {
                using (HealthPlanDatabaseEntities dc = new HealthPlanDatabaseEntities())
                {
                    var v = dc.LoginUsers.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedUserID"] = v.UserId.ToString();
                        Session["LoggedUserFullName"] = v.FullName.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(u);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LoggedUserID"] != null)
            {
                return RedirectToAction("Index", "HealthPlans");
            }

            else
            {
                return RedirectToAction("Index");
            }

        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}