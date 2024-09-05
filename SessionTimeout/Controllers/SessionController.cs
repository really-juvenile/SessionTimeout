using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionTimeout.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            Session["User"] = "John Doe";
            Session["LastAccessTime"] = DateTime.Now;
            return View();
        }
        public ActionResult GetSession()
        {
            // Retrieve session values
            string user = Session["User"] as string;
            DateTime? lastAccessTime = Session["LastAccessTime"] as DateTime?;

            if (user != null && lastAccessTime != null)
            {
                ViewBag.Message = $"User: {user}, Last Access Time: {lastAccessTime}";
            }
            else
            {
                ViewBag.Message = "Session has expired or not set.";
            }

            return View();
        }

        public ActionResult CheckSessionTimeout()
        {
            // Check if session exists
            if (Session["User"] == null)
            {
                return RedirectToAction("SessionExpired");
            }

            // Update session last access time
            Session["LastAccessTime"] = DateTime.Now;

            return View();
        }

        public ActionResult SessionExpired()
        {
            return View();
        }
    }
}