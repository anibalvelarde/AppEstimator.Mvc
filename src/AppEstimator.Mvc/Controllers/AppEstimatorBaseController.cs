using AppEstimator.Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppEstimator.Mvc.Controllers
{
    public abstract class AppEstimatorBaseController : Controller
    {
        private readonly IApiUrlBase _apiAccess;

        public AppEstimatorBaseController(IApiUrlBase api)
        {
            _apiAccess = api;
        }

        internal IApiUrlBase API
        {
            get
            {
                return _apiAccess;
            }
        }
    }
}