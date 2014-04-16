using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMnPRM.Plug.Core;

namespace HRMnPRM.Plug.Domain
{
    public class EmailAccount : BaseModel
    {
        public virtual string Email { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Host { get; set; }

        public virtual int Port { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual bool EnableSsl { get; set; }

        public virtual bool UseDefaultCredentials { get; set; }

        public virtual string FriendlyName
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(this.DisplayName))
                    return this.Email + " (" + this.DisplayName + ")";
                return this.Email;
            }
        }
    }
}
