using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Class for Inserting a Ticket Claim Command
    /// </summary>
    public class InsertTicketClaim : DefaultCommand
    {
           public TicketClaims TicketClaim { get; private set; }

        /// <summary>
        /// Insert Ticket Claim Command Constructor 
        /// </summary>
        public InsertTicketClaim(TicketClaims ticketClaim)
        {
            TicketClaim = ticketClaim;
        }
    }
}