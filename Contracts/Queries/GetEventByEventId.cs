using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Class to retrieve an event based on it's id
    /// </summary>
    public class GetEventByEventId : IQuery<Event>
    {
        public int EventId;

        /// <summary>
        /// Get event by event id constructor
        /// </summary>
        public GetEventByEventId(int eventId)
        {
            EventId = eventId;
        }
    }
}