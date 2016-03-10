using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Mvc.Models
{
    public class NotImplementedViewModel
    {
        public NotImplementedViewModel(string message, string redirectUrl)
        {
            this.Message = message;
            this.RedirectUrl = redirectUrl;
        }

        public string Message { get; private set; }
        public string RedirectUrl { get; private set; }
    }
}