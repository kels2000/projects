#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="ViewNames.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Constants
{
    /// <summary>
    /// Holds all of the paths/names of views
    /// </summary>
    public class ViewNames
    {
        /// <summary>
        /// PostDetails view path
        /// </summary>
        public static readonly string PostDetails = "~/Views/Post/PostDetails.cshtml";

        /// <summary>
        /// CreatePost view path
        /// </summary>
        public static readonly string CreatePost = "~/Views/Post/CreatePost.cshtml";

        /// <summary>
        /// Index for post view path
        /// </summary>
        public static readonly string PostIndex = "~/Views/Post/Index.cshtml";

        /// <summary>
        /// _createNewEvent view path
        /// </summary>
        public static readonly string CreateEventPost = "~/Views/Admin/_createNewEvent.cshtml";

        /// <summary>
        /// _ticketClaims view path
        /// </summary>
        public static readonly string TicketClaims = "~/Views/Admin/_ticketClaims.cshtml";

        /// <summary>
        /// SelectTicketGiveawayWinner view path
        /// </summary>
        public static readonly string SelectTicketWinner = "~/Views/Admin/SelectTicketGiveawayWinner.cshtml";

        /// <summary>
        /// EventSearchResults view path
        /// </summary>
        public static readonly string EventSearchResults = "~/Views/Events/EventSearchResults.cshtml";

        /// <summary>
        /// EventDetails view path
        /// </summary>
        public static readonly string EventDetails = "~/Views/Events/EventDetails.cshtml";

        /// <summary>
        /// TicketHubHome view path
        /// </summary>
        public static readonly string TicketHubHome = "~/Views/Events/TicketHubHome.cshtml";

        /// <summary>
        /// TeamMemberPostHome view path
        /// </summary>
        public static readonly string TeamMemberPostHome = "~/Views/Post/TeamMemberPostHome.cshtml";

        /// <summary>
        /// Index for admin home view path
        /// </summary>
        public static readonly string AdminHomePage = "~/Views/Admin/Index.cshtml";

        /// <summary>
        /// _addAdmin view path
        /// </summary>
        public static readonly string AddAdmin = "~/Views/Admin/_addAdmin.cshtml";

        /// <summary>
        /// _updateEvents view path
        /// </summary>
        public static readonly string UpdateEvents = "~/Views/Admin/_updateEvents.cshtml";

        /// <summary>
        /// _utilitiesDropdown view path
        /// </summary>
        public static readonly string UtilitiesDropdown = "~/Views/Utilities/_utilitiesDropdown.cshtml";

        /// <summary>
        /// _MyPosts view path
        /// </summary>
        public static readonly string MyPostsTable = "~/Views/Profile/_MyPosts.cshtml";

        /// <summary>
        /// View for users without an ADFS Saml Account Name
        /// </summary>
        public static readonly string FailedToAuthenticate = "~/Views/Account/FailedToAuthenticate.cshtml";
    }
}