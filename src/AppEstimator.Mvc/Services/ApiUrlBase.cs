using AppEstimator.Web.Common.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace AppEstimator.Mvc.Services
{
    public class ApiUrlBase : IApiUrlBase
    {
        private readonly IWebUserSession _userSession;
        private Uri _urlBase = null;
        private string _resourceName = string.Empty;
        private string _guestUser = "AnibalUser";

        public ApiUrlBase(IWebUserSession userSession)
        {
            _userSession = userSession;
            this.SetBasicUriElements();
        }

        private string Scheme { get; set; }
        private string Host { get; set; }
        private int Port { get; set; }

        private void SetBasicUriElements()
        {
            if(_userSession.RequestUri.Host.Contains("localhost"))
            {
                this.Scheme = "http";
                this.Host = _userSession.RequestUri.Host;
                this.Port = 9555;
            }
            else
            {
                this.Scheme = "https";
                this.Host = ConfigurationManager.AppSettings["HostingSite"];
                this.Port = 443;
            }          
        }

        public void SetApiResource(string resourceName)
        {
            _resourceName = resourceName;
        }

        public T ExecuteOperation<T>(string apiCallFragment)
        {
            WebClient client = new WebClient();
            string url = this.GetUrlBase() + apiCallFragment;
            //'User' is a Model class that I have defined.
            return JsonConvert.DeserializeObject<T>(client.DownloadString(this.MakeUrl(apiCallFragment)));
        }

        private string GetUrlBase()
        {
            if(_urlBase == null)
            {
                string apiVersion = "v1";

                var uriBuilder = new UriBuilder
                {
                    Scheme = this.Scheme,
                    Host = this.Host,
                    Port = this.Port,
                    Path = string.Format("api/{0}", apiVersion)
                };
                _urlBase = uriBuilder.Uri;
            }
            return _urlBase.AbsoluteUri;
        }

        private string MakeUrl(string fragment)
        {
            return string.Format("{0}/{1}/{2}", this.GetUrlBase(),this._resourceName, fragment);
        }

        private string MakeUrl(string resource, string fragment)
        {
            return string.Format("{0}/{1}/{2}", this.GetUrlBase(), resource, fragment);
        }

        public T ExecuteOperation<T>(string apiCallFragment, System.Net.Http.HttpMethod httpMethod, string resource)
        {
            return this.ExecuteApiOperation<T>(apiCallFragment, httpMethod, resource);
        }

        public T ExecuteOperation<T>(string apiCallFragment, System.Net.Http.HttpMethod httpMethod)
        {
            return this.ExecuteApiOperation<T>(apiCallFragment, httpMethod);
        }

        private T ExecuteApiOperation<T>(string apiCallFragment, System.Net.Http.HttpMethod httpMethod, string resource = "")
        {
            HttpWebRequest request = null;
            if (string.IsNullOrEmpty(resource))
            {
                request = (HttpWebRequest)HttpWebRequest.Create(this.MakeUrl(apiCallFragment));
            }
            else
            {
                request = (HttpWebRequest)HttpWebRequest.Create(this.MakeUrl(resource, apiCallFragment));
            }
            request.Method = httpMethod.Method;
            this.SetBasicAuthHeader(request, this._guestUser, "");
            String data = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                data = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
             }
            return JsonConvert.DeserializeObject<T>(data);
        }

        private void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }
    }
}