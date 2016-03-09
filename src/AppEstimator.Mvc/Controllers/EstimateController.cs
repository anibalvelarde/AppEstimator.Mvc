using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppEstimator.Web.Api.Models;
using AppEstimator.Mvc.Services;
using System.Net.Http;
using AppEstimator.Mvc.Models;

namespace AppEstimator.Mvc.Controllers
{
    public class EstimateController : AppEstimatorBaseController
    {
        public EstimateController(IApiUrlBase api)
            :base(api)
        {
            // based on REST Api principles, the default Api resource for this controller is the Estimate
            this.API.SetApiResource("estimates");
        }

        // GET: Estimate/Details/5
        public ActionResult Details(int id)
        {
            var estimate = this.API.ExecuteOperation<Estimate>(string.Format("/{0}", id), HttpMethod.Get);
            var vm = new EstimateViewModel(estimate);
            return View(vm);
        }

        // GET: Estimate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estimate/Create
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

        // GET: Estimate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estimate/Edit/5
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

        // GET: Estimate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estimate/Delete/5
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
