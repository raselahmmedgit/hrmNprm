using System.Web.Mvc;

namespace HRMnPRM.Plug.Web.Areas.PRM
{
    public class PRMAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PRM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PRM_default",
                "PRM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
