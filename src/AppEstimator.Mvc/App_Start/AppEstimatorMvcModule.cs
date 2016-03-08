using AppEstimator.Mvc.Services;
using AppEstimator.Web.Common.Security;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Mvc.App_Start
{
    public class AppEstimatorMvcModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserSession>()
                .As<IWebUserSession>()
                .SingleInstance();
            builder.RegisterType<ApiUrlBase>()
                .As<IApiUrlBase>()
                .InstancePerRequest();
        }

    }
}