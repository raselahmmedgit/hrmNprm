using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;
using HRMnPRM.Plug.Data;

namespace HRMnPRM.Plug.Service
{
    public static class DbInitializerHelper
    {
        public static bool DefaultInitializeAndSeedDb()
        {
            bool isInitialized = false;

            try
            {
                // Initializes and seeds the database.
                Database.SetInitializer(new DbInitializer());

                using (var context = new AppDbContext())
                {
                    context.Database.Initialize(force: true);
                }

                return isInitialized;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isInitialized;
        }

        public static bool InitializeAndSeedDb()
        {
            bool isInitialized = false;

            try
            {
                DataSettings dataSettings = DbSettings.GetDataSettings();

                if (dataSettings != null)
                {
                    //SqlConnectionFactory sqlConnectionFactory = new SqlConnectionFactory();
                    //sqlConnectionFactory.CreateConnection("");

                    // Initializes and seeds the database.
                    Database.SetInitializer(new DbInitializer());

                    //Database.DefaultConnectionFactory = sqlConnectionFactory;

                    //Need to Default Connection Factory
                    //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "", connectionString); //by String
                    Database.DefaultConnectionFactory = new SqlCeConnectionFactory(dataSettings.DataProvider, "", dataSettings.DataConnectionString); //by DataSettings

                    //using (var context = new AppDbContext()) // Create Database to Project bin folder
                    //using (var context = new AppDbContext(connectionString)) // by String
                    using (var context = new AppDbContext(dataSettings.DataConnectionString)) // by DateSettings
                    {
                        context.Database.Initialize(force: true);
                    }

                    return isInitialized;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isInitialized;
        }
    }
}
