using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace USFS.Domain.Me2U.Security
{
    public class PrincipalRepresentation
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsInAdminGroup { get; set; }
        public bool IsInSuperAdminGroup { get; set; }
    }
}
