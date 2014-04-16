using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMnPRM.Plug.ViewModel;

namespace HRMnPRM.Plug.Web.Filters
{
    public class AuthorizationFilterAttribute : AuthorizeAttribute
    {
        #region Fields
        private string area;
        private string controller;
        private string action;
        private string requestType;
        #endregion

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var request = httpContext.Request;
            requestType = request.HttpMethod.ToString();
            area = Convert.ToString(request.RequestContext.RouteData.Values["area"] ?? request["area"]);
            controller = Convert.ToString(request.RequestContext.RouteData.Values["controller"] ?? request["controller"]);
            action = Convert.ToString(request.RequestContext.RouteData.Values["action"] ?? request["action"]);

            if (controller.Equals("Account"))
            {
                return true;
            }
            var isAuthorized = base.AuthorizeCore(httpContext);

            if (isAuthorized)
            {
                var currentUser = httpContext.User.Identity.Name;

                return ValidatePageUrl(controller, action);
            }
            return isAuthorized;
        }

        private bool ValidatePageUrl(string controller, string action)
        {
            if (controller.Contains("Home") && action.Contains("Index")) return true;

            bool flag = true;
            var currentMenus = (List<MenuViewModel>)HttpContext.Current.Session["CurrentMenus"];

            //session out then user compel to signout
            if (currentMenus == null) { System.Web.Security.FormsAuthentication.SignOut(); return false; }

            var visitingMenu = currentMenus.Find(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.MenuUrl.ToLower().Contains(action.ToLower()));

            if (visitingMenu == null && !action.Contains("Index"))
                visitingMenu = (MenuViewModel)HttpContext.Current.Session["CurrentMenu"];

            if (currentMenus != null && action.Contains("Index")) //check view permission
            {
                flag = visitingMenu != null ? visitingMenu.IsAssignedMenu : false;//currentMenus.Exists(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.IsAssignedMenu);
            }
            //else if (currentMenus != null && action.Contains("Create") && requestType.Contains("GET")) // check view permission
            //{
            //    flag = visitingMenu != null ? (visitingMenu.IsAssignedMenu | visitingMenu.IsAddAssigned) : false;//currentMenus.Exists(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.IsAddAssigned);
            //}
            else if (currentMenus != null && action.Contains("Create") && requestType.Contains("POST")) // check add permission
            {
                flag = visitingMenu != null ? visitingMenu.IsAddAssigned : false;//currentMenus.Exists(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.IsAddAssigned);
            }
            else if (currentMenus != null && action.Contains("Edit") && requestType.Contains("POST")) // check update permission
            {
                flag = visitingMenu != null ? visitingMenu.IsEditAssigned : currentMenus.Exists(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.IsEditAssigned);
            }
            else if (currentMenus != null && action.Contains("Delete")) // check delete permission
            {
                flag = visitingMenu != null ? visitingMenu.IsDeleteAssigned : currentMenus.Exists(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.IsDeleteAssigned);
            }

            if (currentMenus != null && currentMenus.Exists(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.MenuUrl.ToLower().Contains(action.ToLower())))
                HttpContext.Current.Session["CurrentMenu"] = visitingMenu; //currentMenus.Find(x => x.MenuUrl.ToLower().Contains(controller.ToLower()) && x.MenuUrl.ToLower().Contains(action.ToLower()));

            return flag;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    //filterContext.Result = new RedirectResult("~/Account/LogOn");
            //    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            //    filterContext.Result = new RedirectResult(urlHelper.Action("LogOn", "Account"));
            //}
            //else
            //{
            //    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            //    filterContext.Result = new RedirectResult(urlHelper.Action("Unauthorized", "Home"));
            //}
        }

    }
}