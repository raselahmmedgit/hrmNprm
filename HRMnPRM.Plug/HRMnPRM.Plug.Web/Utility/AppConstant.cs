using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMnPRM.Plug.Core;
using HRMnPRM.Plug.ViewModel;

namespace HRMnPRM.Plug.Web
{
    public class AppConstant
    {
        #region Fields
        private static MenuViewModel currentMenuViewModel;
        #endregion

        #region Ctor
        public AppConstant()
        {
            if ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"] != null)
                currentMenuViewModel = (MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"];
            else
                currentMenuViewModel = new MenuViewModel();

        }
        #endregion

        public static string ProjectName
        {
            get
            {
                string projectName = string.Empty;
                if (System.Configuration.ConfigurationManager.AppSettings["projectName"] != null)
                {
                    return System.Configuration.ConfigurationManager.AppSettings["projectName"].ToString();
                }
                else
                {
                    projectName = "Admin";
                }
                return projectName;
            }
        }
        public static Int32 PageSize
        {

            get { return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["pageSize"].ToString()); }
        }
        public static string ImageUploadPath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["imageUploadPath"]; }
        }
        public static string FileUploadPath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["fileUploadPath"]; }
        }

        public static string ApplicationName
        {
            get { return "Schema"; }
        }

        //Current User Info.
        public static UserViewModel UserViewModel
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserModel"] == null)
                    return new UserViewModel();
                else
                    return (UserViewModel)System.Web.HttpContext.Current.Session["UserModel"];
            }
        }

        //Right Permission
        public static bool IsApproveAssigned
        {
            //get { return SecurityAgent.GetRightByLoginIdAndRightName(HttpContext.Current.User.Identity.Name, "Approve").IsAssignedRight; }
            get { return Convert.ToBoolean(HttpContext.Current.Session["User_Identity_Name"].ToString().Split('|')[10]); }
        }
        public static bool IsLockAssigned
        {
            //get { return SecurityAgent.GetRightByLoginIdAndRightName(HttpContext.Current.User.Identity.Name, "Lock").IsAssignedRight; }
            get { return Convert.ToBoolean(HttpContext.Current.Session["User_Identity_Name"].ToString().Split('|')[11]); }
        }
        public static bool IsAttachmentsAssigned
        {
            //get { return SecurityAgent.GetRightByLoginIdAndRightName(HttpContext.Current.User.Identity.Name, "Attachments").IsAssignedRight; }
            get { return Convert.ToBoolean(HttpContext.Current.Session["User_Identity_Name"].ToString().Split('|')[13]); }
        }

        //Menu Permission
        public bool IsDetailsAssigned
        {
            get
            {
                return HttpContext.Current.Session["CurrentMenuModel"] == null ? false : ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"]).IsAssignedMenu;
            }
        }
        public bool IsAddAssigned
        {
            get
            {
                return HttpContext.Current.Session["CurrentMenuModel"] == null ? false : ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"]).IsAddAssigned;
            }
        }
        public bool IsEditAssigned
        {
            get
            {
                return HttpContext.Current.Session["CurrentMenuModel"] == null ? false : ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"]).IsEditAssigned;
            }
        }
        public bool IsDeleteAssigned
        {
            get
            {
                return HttpContext.Current.Session["CurrentMenuModel"] == null ? false : ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"]).IsDeleteAssigned;
            }
        }
        public bool IsCancelAssigned
        {
            get
            {
                return HttpContext.Current.Session["CurrentMenuModel"] == null ? false : ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"]).IsCancelAssigned;
            }
        }
        public bool IsPrintAssigned
        {
            get
            {
                return HttpContext.Current.Session["CurrentMenuModel"] == null ? false : ((MenuViewModel)HttpContext.Current.Session["CurrentMenuModel"]).IsPrintAssigned;
            }
        }

        //DataSettings
        public DataSettings DataSettings
        {
            get
            {
                return DbSettings.GetDataSettings();
            }
        }
    }
}