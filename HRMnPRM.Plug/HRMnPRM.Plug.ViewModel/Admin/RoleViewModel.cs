using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.ViewModel
{
    public class RoleViewModel : BaseViewModel
    {
        [Key]
        [Display(Name = "Role Name")]
        public virtual string RoleName { get; set; }

        public virtual ICollection<UserViewModel> UserViewModels { get; set; }
    }
}
