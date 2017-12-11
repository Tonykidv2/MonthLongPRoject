using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //if (HttpContext.Current.Request.HttpMethod != "OPTIONS") return;
            //HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
            //HttpContext.Current.Response.End();
            //var res = HttpContext.Current.Response;
            //var req = HttpContext.Current.Request;
            //res.AppendHeader("Access-Control-Allow-Origin", "*");
            //res.AppendHeader("Access-Control-Allow-Credentials", "true");
            //res.AppendHeader("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            //res.AppendHeader("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");

            //// ==== Respond to the OPTIONS verb =====
            //if (req.HttpMethod == "OPTIONS")
            //{
            //    res.StatusCode = 200;
            //    res.End();
            //}
        }
    }
}
