using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.Win32;
using System.IO;
using System.Configuration;

namespace HRMnPRM.Plug.Core
{
    public static class DbSettings
    {

        public static string GetConnectionString()
        {
            string connectionString = string.Empty;

            connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;

            return connectionString;
        }

        public static DataSettings GetDataSettings()
        {
            try
            {
                // if AppSetting File Exist
                if (IsAppSettingExists() && IsSqlCompact40Installed())
                {
                    //return ReadConnectionStringFromAppSetting();
                    //return ReadConnectionStringFromTextAppSetting();
                    //return ReadConnectionStringFromXmlAppSetting();
                    return ReadConnectionStringFromWebConfigAppSetting();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteConnectionStringToAppSetting()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteConnectionStringToXmlAppSetting()
        {
            try
            {
                XmlHelper.WriteConnectionStringToXml(AppLocalSetting.AppSettingsXmlFilePath);
                //XmlHelper.WriteConnectionStringToXml(AppLocalSetting.AppSettingsXmlFilePath, "ds", "ic", "is", "pn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteConnectionStringToTextAppSetting()
        {
            try
            {
                TextHelper.WriteConnectionStringToText(AppLocalSetting.AppSettingsFilePath);
                //TextHelper.WriteConnectionStringToText(AppLocalSetting.AppSettingsFilePath, "ds", "ic", "is", "pn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteConnectionStringToWebConfigAppSetting()
        {
            try
            {
                WebConfigHelper.WriteConnectionStringToWebConfig(AppLocalSetting.AppSettingsFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataSettings ReadConnectionStringFromAppSetting()
        {
            try
            {
                DataSettings dataSettings = TextHelper.ReadConnectionStringFromText(AppLocalSetting.AppSettingsFilePath);
                if (dataSettings.IsValid())
                {
                    return dataSettings;
                }
                else
                {
                    return new DataSettings();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataSettings ReadConnectionStringFromTextAppSetting()
        {
            try
            {
                DataSettings dataSettings = TextHelper.ReadConnectionStringFromText(AppLocalSetting.AppSettingsFilePath);
                if (dataSettings.IsValid())
                {
                    return dataSettings;
                }
                else
                {
                    return new DataSettings();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataSettings ReadConnectionStringFromXmlAppSetting()
        {
            try
            {
                DataSettings dataSettings = XmlHelper.ReadConnectionStringFromXml(AppLocalSetting.AppSettingsXmlFilePath);
                if (dataSettings.IsValid())
                {
                    return dataSettings;
                }
                else
                {
                    return new DataSettings();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataSettings ReadConnectionStringFromWebConfigAppSetting()
        {
            try
            {
                DataSettings dataSettings = WebConfigHelper.ReadConnectionStringFromWebConfig();
                if (dataSettings.IsValid())
                {
                    return dataSettings;
                }
                else
                {
                    return new DataSettings();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Check SqlCompact for 32bit/64bit
        private static bool IsSqlCompact40Installed()
        {
            var rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server Compact Edition\\v4.0");
            return rk != null;
        }

        private static bool IsAppSettingExists()
        {
            bool isAppSettingsExists = false;

            try
            {
                // Determine whether the directory and file exists. 
                if (File.Exists(AppLocalSetting.AppDataPath)) // Checking Application Folder and Application Setting File if not exists
                {
                    isAppSettingsExists = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isAppSettingsExists;
        }

        private static bool IsCreateAppSettingFile()
        {
            bool isCreateAppSettingsFile = false;

            try
            {
                // Create the directory and file. 
                if (CommonHelper.CreateAppSettingFile())
                {
                    isCreateAppSettingsFile = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isCreateAppSettingsFile;
        }
    }
}
