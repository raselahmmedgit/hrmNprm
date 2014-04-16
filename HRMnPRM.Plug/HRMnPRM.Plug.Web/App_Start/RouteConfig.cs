using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults:
                    !HasDatabaseCreated()
                        ? new { controller = "Install", action = "Index", id = UrlParameter.Optional }
                        : new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }

        private static bool HasDatabaseCreated()
        {
            bool isCreated = false;

            try
            {
                isCreated = WebConfigHelper.ReadHasDatabaseFromWebConfig();
                return isCreated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}