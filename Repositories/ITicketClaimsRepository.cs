#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="ITicketClaimsRepository.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc. 2017.
// 
//     Copyright in the application source code, and in the information and
//     material therein and in their arrangement, is owned by United Shore Financial Services LLC.
//     unless otherwise indicated.
// 
//     You shall not remove or obscure any copyright, trademark or other notices.
//     You may not copy, republish, redistribute, transmit, participate in the
//     transmission of, create derivatives of, alter edit or exploit in any
//     manner any material including by storage on retrieval systems, without the
//     express written permission of United Shore Financial Services LLC.
// </copyright>
//------------------------------------------------------------------------------------------

#endregion

using System.Collections.Generic;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// interface for ticket clims repository.
    /// </summary>
    public interface ITicketClaimsRepository
    {
        /// <summary>
        /// Inserts a ticket claim into the database
        /// </summary>
        /// <param name="ticketClaim">information about the ticket claim.</param>
        void InsertTicketClaim(TicketClaims ticketClaim );

        /// <summary>
        /// Gets all of the ticket claims for an event.
        /// </summary>
        /// <param name="eventId">the id of the event we are trying to get the claims for</param>
        /// <returns>a list of the ticket claims for an event</returns>
        List<TicketClaims> GetTicketClaimsByEventId(int eventId);

        /// <summary>
        /// Inserts an individual who was chosen to win tickets for an event.
        /// </summary>
        /// <param name="ticketWinner">Information about the individual who won tickets.</param>
        void InsertTicketWinner(TicketWinner ticketWinner);

        /// <summary>
        /// Updates the number of remaining wins for an event.
        /// </summary>
        /// <param name="eventId">the id of the event</param>
        /// <param name="remainingWins">the number of remaining winners for the event.</param>
        void UpdateRemainingWinnersForEvent(int eventId, int remainingWins);
    }
}