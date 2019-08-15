using System;
using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.Security;

namespace USFS.Domain.Me2U.Contracts.Queries
{

    /// <summary>
    /// The GetUserPermissionsQuery class
    /// </summary>
    public class GetUserPermissionsQuery : IQuery<IList<UserPermissions>>
    {
        /// <summary>The user Id to retrieve permissions</summary>
        public Int32 UserId { get; set; }

        /// <summary>
        /// Constructor for UserHasPermissionQuery
        /// </summary>
        /// <param name="user">Current User</param>      
        public GetUserPermissionsQuery(Int32 userId)
        {
            this.UserId = userId;
        }
    }
}
