using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionsDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult SetSession()
        {
            // Set session variable "UserName"
            Session["UserName"] = "John Doe";
            ViewBag.Message = "Session Set";
            return View();
        }

        // Action to get session data
        public ActionResult GetSession()
        {
            // Check if session variable exists and retrieve it
            if (Session["UserName"] != null)
            {
                ViewBag.UserName = Session["UserName"].ToString();
            }
            else
            {
                ViewBag.UserName = "Session is empty!";
            }
            return View();
        }

        // Action to remove session data
        public ActionResult RemoveSession()
        {
            // Remove session variable
            Session.Remove("UserName");
            ViewBag.Message = "Session Removed";
            return View();
        }
    }
}