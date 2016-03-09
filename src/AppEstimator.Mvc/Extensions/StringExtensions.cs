using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Mvc.Extensions
{
    public static class StringExtensions
    {
        public static bool ToBoolean(this string value)
        {
            switch (value)
            {
                case "true":
                    return true;
                case "t":
                    return true;
                case "1":
                    return true;
                case "false":
                    return false;
                case "f":
                    return false;
                case "0":
                    return false;
                case "":
                    return false;
                case null:
                    return false;
                default:
                    throw new InvalidCastException(string.Format("You can't cast a weird value [{0}] to a bool!", value));
            }
        }
    }
}