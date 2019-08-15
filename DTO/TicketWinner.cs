#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="TicketWinner.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.DTO
{
    /// <summary>
    /// Class for holding the information about a ticket winner
    /// </summary>
    public class TicketWinner
    {
        /// <summary>
        /// the email address of an individual who won tickets.
        /// </summary>
        public string EmployeeEmailAddress { get; private set; }

        /// <summary>
        /// the id of the event that the individual won tickets for.
        /// </summary>
        public int EventId { get; private set; }
        
        /// <summary>
        /// The user name of the individual who has chosen the winner.
        /// </summary>
        public string AdminUserName { get; private set; }

        /// <summary>
        /// The user name of the individual who has been chosen to recieve tickets.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Construtor for ticketwinner (2 params)
        /// </summary>
        /// <param name="employeeEmailAddress">the email address of the individual who won tickets.</param>
        /// <param name="eventId">the id of the event that the individual won tickets for.</param>
        /// <param name="userName">The user name of the inividual who has been chosen to get tickets</param>
        public TicketWinner(string employeeEmailAddress, int eventId, string userName, string adminUserName) {
            EmployeeEmailAddress = employeeEmailAddress;
            EventId = eventId;
            UserName = userName;
            AdminUserName = adminUserName;
        }
    }
}
