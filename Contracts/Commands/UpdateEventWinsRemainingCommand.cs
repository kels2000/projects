#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="UpdateEventWinsRemainingCommand.cs" company="United Shore Financial Services LLC.">
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
    /// Class that handles the update event wins remaining command
    /// </summary>
    public class UpdateEventWinsRemainingCommand : DefaultCommand
    {
        /// <summary>
        /// The id of the event that is being updating.
        /// </summary>
        public int Eventid { get; private set; }

        /// <summary>
        /// The number of ticket winners reamaining. 
        /// </summary>
        public int WinsRemaining { get; private set; }

        /// <summary>
        /// Constructor for Update event wins remaing command
        /// </summary>
        /// <param name="eventId">The id of the event that is being updated</param>
        /// <param name="winsRemaining">the number of ticket winners remaining</param>
        public UpdateEventWinsRemainingCommand (int eventId, int winsRemaining)
        {
            Eventid = eventId;
            WinsRemaining = winsRemaining;
        }

    }
}
