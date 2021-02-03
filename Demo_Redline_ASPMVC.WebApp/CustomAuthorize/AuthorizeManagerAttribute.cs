using Demo_Redline_ASPMVC.WebApp.Models;
using Demo_Redline_ASPMVC.WebApp.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo_Redline_ASPMVC.WebApp.CustomAuthorize
{

    public class AuthorizeManagerAttribute : AuthorizeAttribute
    {
        private List<MemberProfil.RoleEnum> roles;

        public AuthorizeManagerAttribute(params MemberProfil.RoleEnum[] roles)
        {
            this.roles = roles.ToList();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionHelper.IsAdmin) 
                return;

            if (!SessionHelper.IsLogged)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary()
                    {
                        { "action", "Login" },
                        { "controller", "Member" }
                    }
                );
            }
            else if (!roles.Contains(SessionHelper.Member.Role))
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

        }
    }
}