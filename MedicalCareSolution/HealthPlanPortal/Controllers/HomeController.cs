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
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Login");
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
                using (HealthPlanDBEntities dc = new HealthPlanDBEntities())
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
                return RedirectToAction("CreateOrganisation"); 
            }

            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult CreateOrganisation()
        {

            return View();
        }
    }
}