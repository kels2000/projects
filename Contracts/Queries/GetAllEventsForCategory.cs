using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Class for Query to Get All Event Previews for a Particular Ticket Category
    /// </summary>
    public class GetAllEventsForCategory : IQuery<List<EventPreview>>
    {
        /// <summary>
        /// CategoryId parameter for stored proc
        /// </summary>
        public int CategoryId { get; private set; }
        /// <summary>
        /// Get All Events By Category Constructor
        /// </summary>
        public GetAllEventsForCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

    }
}
