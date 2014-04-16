using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.Domain
{
    public class Menu : BaseModel
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

        public int ParentMenuId { get; set; }
        public Menu ParentMenu { get; set; }

        public int ApplicationModuleId { get; set; }
        public ApplicationModule ApplicationModule { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
