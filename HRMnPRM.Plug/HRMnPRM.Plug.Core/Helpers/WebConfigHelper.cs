using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace HRMnPRM.Plug.Core
{
    public static class WebConfigHelper
    {
        #region Write To WebConfig File


        /// <summary>
        /// Writing Default Connection String To AppSetting WebConfig File
        /// </summary>
        /// <param name="model"></param>
        /// <returns type="bool"></returns>
        public static bool WriteConnectionStringToWebConfig(AppSettingsViewModel model)
        {
            bool isSaved = false;

            try
            {
                if (model == null)
                    throw new ArgumentNullException("fileName");

                //creating ConnectionString
                string conString = "Data Source=" + AppLocalSetting.AppDefaultDbFilePath;

                // creating ProviderName
                //string proName = "providerName=" + "System.Data.SqlServerCe.4.0";
                string proName = "System.Data.SqlServerCe.4.0";

                //Helps to open the Root level web.config file.
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

                //Modifying the AppKey from AppValue to AppValue1
                webConfigApp.AppSettings.Settings["hasDatabase"].Value = "true";
                webConfigApp.AppSettings.Settings["dbContext"].Value = model.DbContextName;
                webConfigApp.AppSettings.Settings["connectionName"].Value = model.ConnectionName;
                webConfigApp.AppSettings.Settings["connectionString"].Value = model.ConnectionString;
                webConfigApp.AppSettings.Settings["serverName"].Value = model.ServerName;
                webConfigApp.AppSettings.Settings["databaseName"].Value = model.DatabaseName;
                webConfigApp.AppSettings.Settings["dbUserName"].Value = model.DbUserName;
                webConfigApp.AppSettings.Settings["dbPassword"].Value = model.DbPassword;
                webConfigApp.AppSettings.Settings["isIntegratedSecurity"].Value = model.IsIntegratedSecurity.ToString();
                webConfigApp.AppSettings.Settings["providerName"].Value = model.ProviderName;
                webConfigApp.AppSettings.Settings["dbType"].Value = model.DbType;

                //Save the Modified settings of AppSettings.
                webConfigApp.Save();

                isSaved = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }


        /// <summary>
        /// Writing Default Connection String To AppSetting WebConfig File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns type="bool"></returns>
        public static bool WriteConnectionStringToWebConfig(string fileName)
        {
            bool isSaved = false;

            try
            {
                if (string.IsNullOrEmpty(fileName))
                    throw new ArgumentNullException("fileName");

                //creating ConnectionString
                string conString = "Data Source=" + AppLocalSetting.AppDefaultDbFilePath;

                // creating ProviderName
                //string proName = "providerName=" + "System.Data.SqlServerCe.4.0";
                string proName = "System.Data.SqlServerCe.4.0";

                //Helps to open the Root level web.config file.
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

                //Modifying the AppKey from AppValue to AppValue1
                webConfigApp.AppSettings.Settings["hasDatabase"].Value = "true";
                webConfigApp.AppSettings.Settings["dbContext"].Value = "";
                webConfigApp.AppSettings.Settings["connectionName"].Value = conString;
                webConfigApp.AppSettings.Settings["connectionString"].Value = conString;
                webConfigApp.AppSettings.Settings["serverName"].Value = "";
                webConfigApp.AppSettings.Settings["databaseName"].Value = "";
                webConfigApp.AppSettings.Settings["dbUserName"].Value = "";
                webConfigApp.AppSettings.Settings["dbPassword"].Value = "";
                webConfigApp.AppSettings.Settings["isIntegratedSecurity"].Value = "";
                webConfigApp.AppSettings.Settings["providerName"].Value = proName;
                webConfigApp.AppSettings.Settings["dbType"].Value = "";

                //Save the Modified settings of AppSettings.
                webConfigApp.Save();

                isSaved = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        /// <summary>
        /// Writing Custom Database Connection String To AppSetting WebConfig File
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dataSource"></param>
        /// <param name="initialCatalog"></param>
        /// <param name="integratedSecurity"></param>
        /// <param name="providerName"></param>
        /// <returns type="bool"></returns>
        public static bool WriteConnectionStringToWebConfig(string fileName, string dataSource, string initialCatalog, string integratedSecurity, string providerName)
        {
            bool isSaved = false;

            try
            {

                if (string.IsNullOrEmpty(fileName) && string.IsNullOrEmpty(dataSource) && string.IsNullOrEmpty(initialCatalog) && string.IsNullOrEmpty(integratedSecurity) && string.IsNullOrEmpty(providerName))
                    throw new ArgumentNullException("fileName");

                //creating ConnectionString
                string conString = "Data Source=" + dataSource + ";" + "Catalog=" + initialCatalog + ";" + "Integrated Security=" + integratedSecurity + ";";

                // creating ProviderName
                //string proName = "providerName=" + providerName;
                string proName = providerName;

                //Helps to open the Root level web.config file.
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

                //Modifying the AppKey from AppValue to AppValue1
                webConfigApp.AppSettings.Settings["hasDatabase"].Value = "true";
                webConfigApp.AppSettings.Settings["dbContext"].Value = "";
                webConfigApp.AppSettings.Settings["connectionName"].Value = conString;
                webConfigApp.AppSettings.Settings["connectionString"].Value = conString;
                webConfigApp.AppSettings.Settings["serverName"].Value = "";
                webConfigApp.AppSettings.Settings["databaseName"].Value = "";
                webConfigApp.AppSettings.Settings["dbUserName"].Value = "";
                webConfigApp.AppSettings.Settings["dbPassword"].Value = "";
                webConfigApp.AppSettings.Settings["isIntegratedSecurity"].Value = "";
                webConfigApp.AppSettings.Settings["providerName"].Value = proName;
                webConfigApp.AppSettings.Settings["dbType"].Value = "";

                //Save the Modified settings of AppSettings.
                webConfigApp.Save();

                isSaved = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        /// <summary>
        /// Writing Custom Database with User, Password Connection String To AppSettings Text File
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dataSource"></param>
        /// <param name="userId"></param>
        /// <param name="passWord"></param>
        /// <param name="initialCatalog"></param>
        /// <param name="integratedSecurity"></param>
        /// <param name="providerName"></param>
        /// <returns type="bool"></returns>
        public static bool WriteConnectionStringToText(string fileName, string dataSource, string userId, string passWord, string initialCatalog, string integratedSecurity, string providerName)
        {
            bool isSaved = false;

            try
            {

                if (string.IsNullOrEmpty(fileName) && string.IsNullOrEmpty(dataSource) && string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(passWord) && string.IsNullOrEmpty(initialCatalog) && string.IsNullOrEmpty(integratedSecurity) && string.IsNullOrEmpty(providerName))
                    throw new ArgumentNullException("fileName");

                //creating ConnectionString
                string conString = "Data Source=" + dataSource + ";" + "User ID=" + userId + ";" + "Password=" + passWord + ";" + "Catalog=" + initialCatalog + ";" + "Integrated Security=" + integratedSecurity + ";";

                // creating ProviderName
                //string proName = "providerName=" + providerName;
                string proName = providerName;

                //Helps to open the Root level web.config file.
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

                //Modifying the AppKey from AppValue to AppValue1
                webConfigApp.AppSettings.Settings["hasDatabase"].Value = "true";
                webConfigApp.AppSettings.Settings["dbContext"].Value = "";
                webConfigApp.AppSettings.Settings["connectionName"].Value = conString;
                webConfigApp.AppSettings.Settings["connectionString"].Value = conString;
                webConfigApp.AppSettings.Settings["serverName"].Value = "";
                webConfigApp.AppSettings.Settings["databaseName"].Value = "";
                webConfigApp.AppSettings.Settings["dbUserName"].Value = "";
                webConfigApp.AppSettings.Settings["dbPassword"].Value = "";
                webConfigApp.AppSettings.Settings["isIntegratedSecurity"].Value = "";
                webConfigApp.AppSettings.Settings["providerName"].Value = proName;
                webConfigApp.AppSettings.Settings["dbType"].Value = "";

                //Save the Modified settings of AppSettings.
                webConfigApp.Save();

                isSaved = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        /// <summary>
        /// Writing Custom Server Connection String To AppSettings Text File
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="userId"></param>
        /// <param name="passWord"></param>
        /// <param name="initialCatalog"></param>
        /// <param name="integratedSecurity"></param>
        /// <param name="providerName"></param>
        /// <returns type="bool"></returns>
        public static bool WriteConnectionStringToText(string fileName, string serverName, string databaseName, string userId, string passWord, string initialCatalog, string integratedSecurity, string providerName)
        {
            bool isSaved = false;

            try
            {

                if (string.IsNullOrEmpty(fileName) && string.IsNullOrEmpty(serverName) && string.IsNullOrEmpty(databaseName) && string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(passWord) && string.IsNullOrEmpty(initialCatalog) && string.IsNullOrEmpty(integratedSecurity) && string.IsNullOrEmpty(providerName))
                    throw new ArgumentNullException("fileName");

                //creating ConnectionString
                string conString = "Server=" + serverName + "Database=" + databaseName + ";" + "User ID=" + userId + ";" + "Password=" + passWord + ";" + "Catalog=" + initialCatalog + ";" + "Integrated Security=" + integratedSecurity + ";";

                // creating ProviderName
                //string proName = "providerName=" + providerName;
                string proName = providerName;

                //Helps to open the Root level web.config file.
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

                //Modifying the AppKey from AppValue to AppValue1
                webConfigApp.AppSettings.Settings["hasDatabase"].Value = "true";
                webConfigApp.AppSettings.Settings["dbContext"].Value = "";
                webConfigApp.AppSettings.Settings["connectionName"].Value = conString;
                webConfigApp.AppSettings.Settings["connectionString"].Value = conString;
                webConfigApp.AppSettings.Settings["serverName"].Value = "";
                webConfigApp.AppSettings.Settings["databaseName"].Value = "";
                webConfigApp.AppSettings.Settings["dbUserName"].Value = "";
                webConfigApp.AppSettings.Settings["dbPassword"].Value = "";
                webConfigApp.AppSettings.Settings["isIntegratedSecurity"].Value = "";
                webConfigApp.AppSettings.Settings["providerName"].Value = proName;
                webConfigApp.AppSettings.Settings["dbType"].Value = "";

                //Save the Modified settings of AppSettings.
                webConfigApp.Save();

                isSaved = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSaved;
        }

        #endregion Write To Text File

        #region Read From WebConfig File

        /// <summary>
        /// Reading Default Connection String From AppSetting WebConfig File
        /// </summary>
        /// <returns type="DataSettings"></returns>
        public static DataSettings ReadConnectionStringFromWebConfig()
        {
            try
            {
                DataSettings dataSettings;

                var providerName = ConfigurationSettings.AppSettings["providerName"];
                var connectionString = ConfigurationSettings.AppSettings["connectionString"];

                string strProviderName = providerName.ToString();
                string strConnectionString = connectionString.ToString();

                return dataSettings = CommonHelper.ParseDataSettingsFromWebConfig(strProviderName, strConnectionString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reading HasDatabase From AppSetting WebConfig File
        /// </summary>
        /// <returns type="bool"></returns>
        public static bool ReadHasDatabaseFromWebConfig()
        {
            try
            {
                var hasDatabase = ConfigurationSettings.AppSettings["hasDatabase"];

                bool isHasDatabase = Convert.ToBoolean(hasDatabase);

                return isHasDatabase;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Read From Text File
    }
}
