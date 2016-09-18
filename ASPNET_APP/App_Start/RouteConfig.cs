using System;
using System.Web.Routing;

// namespace ASPNET_APP.App_Start
namespace ASPNET_APP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "", "~/Pages/Login.aspx");
        }
    }
}