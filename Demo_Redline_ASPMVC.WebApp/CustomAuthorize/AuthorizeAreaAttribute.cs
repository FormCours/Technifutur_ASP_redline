using Demo_Redline_ASPMVC.WebApp.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo_Redline_ASPMVC.WebApp.CustomAuthorize
{
    public class AuthorizeAreaAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            RouteData routeDate = httpContext.Request.RequestContext.RouteData;
            String area = routeDate.DataTokens["area"]?.ToString();

            switch (area)
            {
                case "Admin":
                    return SessionHelper.IsAdmin;
                // Other area
                // ...
                default:
                    return true;
            }
        }
    }
}