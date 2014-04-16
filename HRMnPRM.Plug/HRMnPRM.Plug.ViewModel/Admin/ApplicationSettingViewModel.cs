using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.ViewModel
{
   public class ApplicationSettingViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int ApplicationViewModelId { get; set; }
        public ApplicationViewModel ApplicationViewModel { get; set; }
    }
}
