using AppEstimator.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppEstimator.Mvc.Controllers
{
    public class NotImplementedController : Controller
    {
        // GET: NotReadyMessage
        public ActionResult Index(string message)
        {
            if (string.IsNullOrEmpty(message)) { message = "Action has not been implemented yet."; }
            var redirectUrl = Request.UrlReferrer.ToString();
            var niVm = new NotImplementedViewModel(message, redirectUrl);
            return View(niVm);
        }
    }
}
