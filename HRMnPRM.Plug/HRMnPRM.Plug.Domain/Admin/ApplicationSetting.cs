using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.Domain
{
    public class ApplicationSetting : BaseModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
