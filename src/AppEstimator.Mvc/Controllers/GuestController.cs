using AppEstimator.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AppEstimator.Web.Api.Models;

namespace AppEstimator.Mvc.Controllers
{
    public class GuestController : Controller
    {
        private readonly IApiUrlBase _apiUrlBase;

        public GuestController(IApiUrlBase apiUrlBase)
        {
            _apiUrlBase = apiUrlBase;
            _apiUrlBase.SetApiResource("users");
        }

        // GET: Guest
        public ActionResult Index()
        {
            var result = this._apiUrlBase.ExecuteOperation<List<AppUserInfo>>("", HttpMethod.Get, null);
            var guestsOnlyResult = result.Where(x => x.IsGuestUser == true).ToList();
            return View(guestsOnlyResult);
        }

        // GET: Guest/Details/5
        public ActionResult Details(int id)
        {
            var user = this._apiUrlBase.ExecuteOperation<AppUser>(string.Format("{0}", id), HttpMethod.Get, null);
            var estimates = this._apiUrlBase.ExecuteOperation<List<EstimateInfo>>(string.Format("/?userId={0}",id), HttpMethod.Get, "estimates");

            Models.GuestUserViewModel result = new Models.GuestUserViewModel(user, estimates);
            return View(result);
        }

        // GET: Guest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guest/Create
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

        // GET: Guest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Guest/Edit/5
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

        // GET: Guest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Guest/Delete/5
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
