using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMnPRM.Plug.ViewModel
{
    public class AppSettingsViewModel
    {
        public string DbContextName { get; set; }
        public string ConnectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataSource { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public string DbInitialCatalog { get; set; }
        public bool IsIntegratedSecurity { get; set; }
        public string ProviderName { get; set; }
        public string DbType { get; set; }
    }
}
