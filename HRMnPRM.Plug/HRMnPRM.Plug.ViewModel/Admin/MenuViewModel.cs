using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public int MenuCode { get; set; }
        public string MenuShortName { get; set; }
        public string MenuName { get; set; }
        public string MenuText { get; set; }
        public string MenuImageUrl { get; set; }
        public string MenuUrl { get; set; }
        public string MenuSpriteCssClass { get; set; }
        public string MenuActionName { get; set; }
        public string MenuUrlTarget { get; set; }

        public bool IsActive { get; set; }
        public int SerialNo { get; set; }

        public bool IsAssignedMenu { get; set; }
        public bool IsDetailsAssigned { get; set; }
        public bool IsAddAssigned { get; set; }
        public bool IsEditAssigned { get; set; }
        public bool IsDeleteAssigned { get; set; }
        public bool IsCancelAssigned { get; set; }
        public bool IsPrintAssigned { get; set; }

        public int ParentMenuViewModelId { get; set; }
        public MenuViewModel ParentMenuViewModel { get; set; }

        public int ApplicationModuleViewModelId { get; set; }
        public ApplicationModuleViewModel ApplicationModuleViewModel { get; set; }

        public virtual ICollection<UserViewModel> UserViewModels { get; set; }
    }
}
