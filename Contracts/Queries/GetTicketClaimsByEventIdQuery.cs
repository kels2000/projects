using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Class to the list of 'Ticket Claims' (the people who raised their hands for an event)
    /// </summary>
    public class GetTicketClaimsByEventIdQuery : IQuery<List<TicketClaims>>
    {
        /// <summary>
        /// Event Id parameter for stored proc
        /// </summary>
        public int EventId { get; private set; }

        /// <summary>
        /// Get ticket claims by event id constructor
        /// </summary>
        public GetTicketClaimsByEventIdQuery(int eventId)
        {
            EventId = eventId;

        }
    }
}