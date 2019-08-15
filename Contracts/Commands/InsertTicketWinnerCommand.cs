#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="InsertTicketWinnerCommand.cs" company="United Shore Financial Services LLC.">
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
using USFS.Core.Command;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Holds information about the Insert ticket winner command
    /// </summary>
    public class InsertTicketWinnerCommand : DefaultCommand
    {
        /// <summary>
        /// a string of ticket winners, separated by a comma
        /// </summary>
        public string TicketWinners { get; private set; }

        /// <summary>
        /// The Id of the event the winners are for.
        /// </summary>
        public int EventId { get; private set; }

        /// <summary>
        /// The username of the individual who has chosen the winners.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Constructor for insert ticket winner command
        /// </summary>
        /// <param name="winners">The winners of tickets (email addresses)</param>
        /// <param name="eventId">the id of the event we are giving away tickets for</param>
        public InsertTicketWinnerCommand(string winners, int eventId, string userName)
        {
            TicketWinners = winners;
            EventId = eventId;
            UserName = userName;
        }
    }
}
