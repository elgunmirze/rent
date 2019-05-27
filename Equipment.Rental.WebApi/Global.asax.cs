using Autofac;
using Equipment.Rental.Services;
using Equipment.Rental.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Equipment.Rental.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(IocConfig.Register);
            GlobalConfiguration.Configure(JsonFormatterConfig.Register);
        }
    }
}
