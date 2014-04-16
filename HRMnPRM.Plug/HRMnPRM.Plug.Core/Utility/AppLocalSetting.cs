using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Globalization;

namespace HRMnPRM.Plug.Core
{
    public static class AppLocalSetting
    {
        public static string AppPath { get; set; }

        //application app_data path
        public static string AppDataPath { get { return HttpContext.Current.Server.MapPath("~/App_Data"); } }
        public static string AppDataLoggerPath { get { return HttpContext.Current.Server.MapPath("~/App_Data/log.txt"); } }

        //my documents path
        public static string MyDocumentPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); } }
        public static string AppMyDocumentFolderPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\appdb"; } }

        //common application data folder path
        public static string AppCommonApplicationDataFolderPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\appdb"; } }

        //application data folder path
        public static string AppApplicationDataFolderPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\appdb"; } }

        //text file path
        public static string AppSettingsFilePath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\appdb\\AppLocalSetting.txt"; } }
        public static string AppCommonSettingsFileName { get { return AppCommonApplicationDataFolderPath + "\\AppLocalSetting.txt"; } }
        public static string AppUserSettingsFileName { get { return AppApplicationDataFolderPath + "\\AppLocalSetting.txt"; } }

        //Database file path
        public static string AppDefaultDbFilePath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\appdb\\appdb.sdf"; } }
        public static string AppCommonDefaultDbFilePath { get { return AppCommonApplicationDataFolderPath + "\\appdb.sdf"; } }
        public static string AppUserDefaultDbFilePath { get { return AppApplicationDataFolderPath + "\\appdb.sdf"; } }

        //xml file path
        public static string AppSettingsXmlFilePath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\appdb\\AppLocalSetting.xml"; } }
        public static string AppCommonSettingsXmlFileName { get { return AppCommonApplicationDataFolderPath + "\\AppLocalSetting.xml"; } }
        public static string AppUserSettingXmlFileName { get { return AppApplicationDataFolderPath + "\\AppLocalSetting.xml"; } }

        public static string AppSettingsFileName { get { return File.Exists(AppUserSettingsFileName) ? AppUserSettingsFileName : AppCommonSettingsFileName; } }

        public static string AppDefaultCurrencyFormat { get; set; }
        public static string AppCurrencySymbol { get { return CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol; } }

        public static int AppDbVersion { get { return 05; } }
        public static string AppVersion { get { return "0.05"; } }

    }
}
