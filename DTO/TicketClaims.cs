#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="TicketClaims.cs" company="United Shore Financial Services LLC.">
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


using System;

namespace USFS.Domain.Me2U.DTO
{
    /// <summary>
    /// Class for holding information about the individuals who have raised their hands for an event.
    /// </summary>
    public class TicketClaims
    {
        /// <summary>
        /// Database value for ticket claim id
        /// </summary>
        public int TicketClaimsId { get; private set; }

        /// <summary>
        /// Database value for event id 
        /// </summary>
        public int EventId { get; private set; }

        /// <summary>
        /// Database value for event name
        /// </summary>
        public string EventName { get; private set; }

        /// <summary>
        /// Database value for team member's first name 
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Database value for team member's last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Database value for team member's email
        /// </summary>
        public string EmailAddress { get; private set; }

        /// <summary>
        /// The number of times an individual has won tickets.
        /// </summary>
        public int NumberOfWins { get; private set; }

        /// <summary>
        /// The number of times an individual has raised their hand.
        /// </summary>
        public int NumberOfTimesRaisedHand { get; private set; }

        /// <summary>
        /// the user name of the individual who has raised their hand for an event.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// The date/time that the individual had raised their hand for an event.
        /// </summary>
        public DateTime RaisedHandDateTime { get; private set; }

        /// <summary>
        /// Ticket Claims object constructor
        /// </summary>
        public TicketClaims
            (int ticketClaimsId,
             int eventId, 
             string eventName, 
             string firstName, 
             string lastName, 
             string eMailAddress,
             string userName)
        {
            TicketClaimsId = ticketClaimsId;
            EventId = eventId;
            EventName = eventName;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = eMailAddress;
            UserName = userName;
        }

        /// <summary>
        /// Ticket Claims object constructor
        /// </summary>
        public TicketClaims
            (int ticketClaimsId,
             int eventId, 
             string eventName, 
             string firstName, 
             string lastName, 
             string eMailAddress,
             string userName,
             DateTime raisedHandDateTime)
        {
            TicketClaimsId = ticketClaimsId;
            EventId = eventId;
            EventName = eventName;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = eMailAddress;
            UserName = userName;
            RaisedHandDateTime = raisedHandDateTime;
        }

        /// <summary>
        /// Ticket Claims object constructor
        /// </summary>
        public TicketClaims
            (int ticketClaimsId,
             int eventId,
             string eventName,
             string firstName,
             string lastName,
             string eMailAddress,
             string userName,
             DateTime raisedHandDateTime,
             int numberOfWins,
             int numberOfTimesRaisedHand) : this(ticketClaimsId, eventId, eventName, firstName, lastName, eMailAddress, userName, raisedHandDateTime)
        {
            NumberOfWins = numberOfWins;
            NumberOfTimesRaisedHand = numberOfTimesRaisedHand;
        }
    }
}