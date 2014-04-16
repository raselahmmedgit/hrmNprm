using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.ViewModel
{
    public class UserMenuPermissionViewModel : BaseViewModel
    {
        public int MenuViewModelId { get; set; }
        public MenuViewModel MenuViewModel { get; set; }

        public int UserViewModelId { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public bool CanDetails { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
