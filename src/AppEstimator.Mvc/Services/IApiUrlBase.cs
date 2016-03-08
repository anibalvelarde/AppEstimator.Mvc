using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Mvc.Services
{
    public interface IApiUrlBase
    {
        void SetApiResource(string resourceName);
        T ExecuteOperation<T>(string apiCallFragment);
        T ExecuteOperation<T>(string apiCallFragment, HttpMethod httpMethod);
        T ExecuteOperation<T>(string apiCallFragment, HttpMethod httpMethod, string resource);
    }
}
