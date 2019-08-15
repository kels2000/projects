using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USFS.Domain.Me2U.Security
{
    /// <summary>
    /// Model class containing the permissionId.
    /// </summary>
    public class UserPermissions
    {
        /// <summary>
        /// The permission Id.
        /// </summary>
        public string PermissionId { get; private set; }

        /// <summary>
        /// Constructs UserPermissions.
        /// </summary>      
        /// <param name="boardingStatus">The permission Id.</param>

        public UserPermissions(string permissionId)
        {
            this.PermissionId = permissionId;
        }
    }
}
