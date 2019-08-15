#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="AdminModel.cs" company="United Shore Financial Services LLC.">
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
    using System.Web.Mvc;
    using USFS.Domain.Me2U.DTO;

    /// <summary>
    /// The adminastrator view viewmodel
    /// </summary>
    public class AdminModel : BaseViewModel
    {
        /// <summary>
        /// Which event is currently being viewed
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// The list of possible events to view
        /// </summary>
        public List<Event> Events { get; set; }

        /// <summary>
        /// The list of ticket claims
        /// </summary>
        public List<TicketClaims> TicketClaims { get; set; }

        /// <summary>
        /// List of pictures related to events
        /// </summary>
        public List<Picture> Pictures { get; set; }

        /// <summary>
        /// The possible event categories
        /// </summary>
        public SelectList EventCategories { get; set; }

        /// <summary>
        /// The possible status of each event
        /// </summary>
        public SelectList EventPostStatus { get; set; }
    }
}