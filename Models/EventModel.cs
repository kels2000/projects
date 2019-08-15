#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EventModel.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc.
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

namespace USFS.WebUI.Me2U.Models
{
    using System.Collections.Generic;
    using USFS.Domain.Me2U.DTO;

    /// <summary>
    /// Model for the event view.
    /// </summary>
    public class EventModel : BaseViewModel
    {
        /// <summary>
        /// Information about an event.
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// Holds a list of events.
        /// </summary>
        public List<Event> Events { get; set; }

        /// <summary>
        /// A list of Ticket Claims
        /// </summary>
        public List<TicketClaims> TicketClaims { get; set; }

        /// <summary>
        /// A list of individuals who have won tickets for an event (email)
        /// </summary>
        public List<TicketWinner> TicketWinners { get; set; }

        /// <summary>
        /// A collection of event previews.
        /// </summary>
        public List<EventPreview> EventPreviews { get; set; }

        /// <summary>
        /// Pictures for events.
        /// </summary>
        public List<Picture> Pictures { get; set; }

        /// <summary>
        /// Information regarding the currently logged in user.
        /// </summary>
        public CurrentUser OrgChartUser { get; set; }

        /// <summary>
        /// the id of the category of the event.
        /// </summary>
        public int CategoryId { get; set; }
    }
}