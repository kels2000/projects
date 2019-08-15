#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="United Shore Financial Services LLC.">
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
using System.Collections.Generic;
using USFS.Domain.Me2U.Enumerations;

namespace USFS.Domain.Me2U.DTO
{
    public class Event
    {
        /// <summary>
        /// Database ID of Post event is related to 
        /// </summary>
        public int EventId { get; set; }
        
        /// <summary>
        /// Name of the Event
        /// </summary>
        public string Venue { get; set; }

        /// <summary>
        /// Description of the Event
        /// </summary>
        public string EventDescription { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Date of the event
        /// </summary>
        public DateTime EventDate { get; set; }
        
        /// <summary>
        /// Database Id for the TicketCategory
        /// </summary>
        public TicketCategoryEnum CategoryId { get; set; }

        /// <summary>
        /// Determines the number of objects available
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Number of claims allowed
        /// </summary>
        public int Claims { get; set; }

        /// <summary>
        /// The maximum number of wins for the event (number of tickets / tickets per claim)
        /// </summary>
        public int MaxNumberOfWins { get; set; }

        /// <summary>
        /// The number of winners that can be selected for the tickets. (changes based on the number of winners chosen.)
        /// </summary>
        public int WinsRemaining { get; set; }

        /// <summary>
        /// Determines status os the post
        /// </summary>
        public TicketPostStatusEnum PostStatus{ get; set; }

        /// <summary>
        /// Date the Post was created
        /// </summary>
        public DateTime DatePosted { get; set; }

        /// <summary>
        /// Get the number of people who have raised their hand for an event
        /// </summary>
        public int TotalHandsRaised { get; set; }

        /// <summary>
        /// A list of winners for an event.
        /// </summary>
        public List<String> WinnersForEvent { get; set; }

        /// <summary>
        /// A list of non-winners for an event.
        /// </summary>
        public List<String> NonWinnersForEvent { get; set; }

        /// <summary>
        /// Event Object Constructor
        /// </summary>
        public Event(int eventId, string venue, string description, string eventName, DateTime eventDate,
            TicketCategoryEnum categoryId, int quantity, int claims, TicketPostStatusEnum postStatus, DateTime datePosted, int totalHandsRaised, int maxWins, int winsRemaining)
        {
            EventId = eventId;
            Venue = venue;
            EventDescription = description;
            EventName = eventName;
            EventDate = eventDate;
            CategoryId = categoryId;
            Quantity = quantity;
            Claims = claims;
            PostStatus = postStatus;
            DatePosted = datePosted;
            TotalHandsRaised = totalHandsRaised;
            MaxNumberOfWins = maxWins;
            WinsRemaining = winsRemaining;
        }

        /// <summary>
        /// Event Object Empty Constructor
        /// </summary>
        public Event()
        {


        }


    }
}
