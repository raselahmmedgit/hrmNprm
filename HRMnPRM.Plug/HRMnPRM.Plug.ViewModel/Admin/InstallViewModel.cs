﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HRMnPRM.Plug.ViewModel.Admin
{
    class InstallViewModel
    {
        [AllowHtml]
        public string AdminEmail { get; set; }
        [AllowHtml]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        [AllowHtml]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        [AllowHtml]
        public string DatabaseConnectionString { get; set; }
        public string DataProvider { get; set; }
        //SQL Server properties
        public string SqlConnectionInfo { get; set; }
        [AllowHtml]
        public string SqlServerName { get; set; }
        [AllowHtml]
        public string SqlDatabaseName { get; set; }
        [AllowHtml]
        public string SqlServerUsername { get; set; }
        [AllowHtml]
        public string SqlServerPassword { get; set; }
        public string SqlAuthenticationType { get; set; }
        public bool SqlServerCreateDatabase { get; set; }

        public bool InstallSampleData { get; set; }
    }
}
