using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.Domain
{
    public class UserMenuPermission : BaseModel
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public bool CanDetails { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
