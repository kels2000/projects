using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;
using USFS.MISMO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Class to get photos based on its event id 
    /// </summary>
    public class GetEventPostPictures : IQuery<List<Picture>>
    {
       public int EventId { get; set; }

        /// <summary>
        /// Get photos by event id constructor
        /// </summary>
        public GetEventPostPictures(int eventId)
        {
            EventId = eventId;
        }
    }
}