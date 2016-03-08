using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppEstimator.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "When was the last time you did something for the first time?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Got questions? Reach out...";

            return View();
        }
    }
}