using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.Domain
{
    public class ApplicationModule : BaseModel
    {
        public string ModuleShortName { get; set; }
        public string ModuleName { get; set; }
        public string ModuleLogoPath { get; set; }

        public bool IsActive { get; set; }
        public int SerialNo { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
