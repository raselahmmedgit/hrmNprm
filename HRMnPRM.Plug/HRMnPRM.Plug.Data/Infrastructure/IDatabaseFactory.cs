using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMnPRM.Plug.Data
{
    public interface IDatabaseFactory : IDisposable
    {
        AppDbContext Get();
    }
}
