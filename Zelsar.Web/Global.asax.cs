﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Zensar.API.Config;

namespace Zelsar.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

       

  
            
            var config = GlobalConfiguration.Configuration;
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            json.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Serialize;
           
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            ApiRouteConfig.RegisterRoutes(config);
            AutofacWebApi.Setup(config);

            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}