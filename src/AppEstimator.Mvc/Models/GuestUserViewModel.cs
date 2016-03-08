using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Mvc.Models
{
    public class GuestUserViewModel
    {
        private readonly AppUser _appUser;
        private readonly List<EstimateInfo> _userEstimates;

        public GuestUserViewModel(AppUser appUser, List<EstimateInfo> userEstimates)
        {
            _appUser = appUser;
            _userEstimates = userEstimates;
        }

        public AppUser User { get { return _appUser; } }
        public List<EstimateInfo> Estimates { get { return _userEstimates; } }
    }
}