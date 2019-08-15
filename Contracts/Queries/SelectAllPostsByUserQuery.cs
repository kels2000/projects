using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{   /// <summary>
    /// Class for Query to Get All Event Previews for a Particular Ticket Category
    /// </summary>
    public class SelectAllPostsByUserQuery: IQuery<List<Post>>
    {
        /// <summary>
        /// Login Name parameter for stored proc
        /// </summary>
        public string LoginName { get; private set; }

        /// <summary>
        /// SelectAllPostsByUserQuery constructor
        /// </summary>
        /// <param name="loginName"></param>
        public SelectAllPostsByUserQuery(string loginName)
        {
            LoginName = loginName;
        }
    }
}
