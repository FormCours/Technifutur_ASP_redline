using Demo_Redline_ASPMVC.WebApp.CustomAuthorize;
using System.Web;
using System.Web.Mvc;

namespace Demo_Redline_ASPMVC.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAreaAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
