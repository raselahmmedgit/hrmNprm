using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.ViewModel
{
    public class ApplicationModuleViewModel : BaseViewModel
    {
        public string ModuleShortName { get; set; }
        public string ModuleName { get; set; }
        public string ModuleLogoPath { get; set; }

        public bool IsActive { get; set; }
        public int SerialNo { get; set; }

        public int ApplicationViewModelId { get; set; }
        public ApplicationViewModel ApplicationViewModel { get; set; }
    }
}
