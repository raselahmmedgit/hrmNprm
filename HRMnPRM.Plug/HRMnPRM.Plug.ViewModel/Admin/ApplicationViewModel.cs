using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.ViewModel
{
    public class ApplicationViewModel : BaseViewModel
    {
        public string ApplicationShortName { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationLogoPath { get; set; }
        public string ApplicationVersionNo { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
        public int SerialNo { get; set; }
    }
}
