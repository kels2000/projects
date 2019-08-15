#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="SendNonWinnerEmailCommand.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Query for sending emails to the non-winners of an event.
    /// </summary>
    public class SendNonWinnerEmailCommand : DefaultCommand
    {
        /// <summary>
        /// The id of the event we are getting the list of non-winners for.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// The name of the event we are sending emails about
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Construtor for SendNonWinnerEmailQuery
        /// </summary>
        /// <param name="eventId">The id of the event to retrieve the list of non-winners</param>
        /// <param name="eventName">The name of the event to send the email about.</param>
        public SendNonWinnerEmailCommand(int eventId, string eventName)
        {
            EventId = eventId;
            EventName = eventName;
        }

    }
}
