#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EventsController.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.ProjectTemplate.WebUIHome.Controllers
{
    using System.Security.Claims;
    using System.Web.Mvc;
    using USFS.Core.Command;
    using USFS.Domain.Me2U.Contracts.Commands;
    using USFS.Domain.Me2U.Contracts.Queries;
    using USFS.Domain.Me2U.DTO;
    using USFS.WebUI.Me2U.Constants;
    using USFS.WebUI.Me2U.Helpers;
    using USFS.WebUI.Me2U.Models;

    /// <summary>
    /// Controller for the events view.
    /// </summary>
    [Authorize]
    public class EventsController : Controller
    {
        /// <summary>
        /// Interface for the command bus
        /// </summary>
        private readonly ICommandBus commandBus;

        /// <summary>
        /// the claims helper
        /// </summary>
        private readonly IClaimsHelper claimsHelper;

        /// <summary>
        /// the logging helper
        /// </summary>
        private readonly ILoggingHelper loggingHelper;

        /// <summary>
        /// Constructor for the events controller
        /// </summary>
        /// <param name="commandBus">the command bus</param>
        /// <param name="claimsHelper">the claims helper</param>
        /// <param name="loggingHelper">the logging helper</param>
        public EventsController(ICommandBus commandBus, IClaimsHelper claimsHelper, ILoggingHelper loggingHelper)
        {
            this.commandBus = commandBus;
            this.claimsHelper = claimsHelper;
            this.loggingHelper = loggingHelper;

        }

        /// <summary>
        /// Loads ticket hub home page
        /// </summary>
        /// <returns>Ticket Hub Home Page</returns>
        public ActionResult Index()
        {
            EventModel model = new EventModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllEventsForCarouselQuery carouselQuery = new GetAllEventsForCarouselQuery();
            model.EventPreviews = commandBus.ProcessQuery(carouselQuery);

            GetAllActiveEventsQuery query = new GetAllActiveEventsQuery();
            model.Events = commandBus.ProcessQuery(query);

            return View(ViewNames.TicketHubHome, model);
        }

        /// <summary>
        /// Loads all the event previews in the database associated with a particular categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Event search results view</returns>
        public ActionResult AllEventsByCategory(int categoryId)
        {
            EventModel model = new EventModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllEventsForCategory query = new GetAllEventsForCategory(categoryId);
            model.EventPreviews = commandBus.ProcessQuery(query);

            model.CategoryId = categoryId;
            return View(ViewNames.EventSearchResults, model);
        }

        /// <summary>
        /// Gets the details of a particular event based on its id
        /// </summary>
        /// <param name="eventId">the id of the event to get the details of</param>
        /// <returns>Event Details View</returns>
        public ActionResult EventDetails(int eventId)
        {
            EventModel model = new EventModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetEventByEventId eventQuery = new GetEventByEventId(eventId);
            model.Event = commandBus.ProcessQuery(eventQuery);

            GetEventPostPictures pictureQuery = new GetEventPostPictures(eventId);
            model.Pictures = commandBus.ProcessQuery(pictureQuery);

            GetTicketClaimsByEventIdQuery ticketClaimQuery = new GetTicketClaimsByEventIdQuery(eventId);
            model.TicketClaims = commandBus.ProcessQuery(ticketClaimQuery);

            SelectUserQuery userQuery = new SelectUserQuery(new CurrentUser { LoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity) });
            model.OrgChartUser = commandBus.ProcessQuery(userQuery);

            return View(ViewNames.EventDetails, model);
        }

        /// <summary>
        /// Adds a team memeber's name to the list of ticket claims for a particular event
        /// </summary>
        /// <param name="loginName">the loginname of the individual who has raised their hand</param>
        /// <param name="eventName">the name of the event</param>
        /// <param name="eventId">the id of the event that the individual is interested in</param>
        public void InterestedInEvent(string loginName, string eventName, int eventId)
        {
            SelectUserQuery userQuery = new SelectUserQuery(new CurrentUser() { LoginName = loginName });
            CurrentUser user = commandBus.ProcessQuery(userQuery);

            TicketClaims claim = new TicketClaims(
                 ticketClaimsId: 0,
                eventName: eventName,
                eventId: eventId,
                firstName: user.FirstName,
                lastName: user.LastName,
                eMailAddress: user.EmailAddress,
                userName: loginName);

            InsertTicketClaim command = new InsertTicketClaim(claim);

            commandBus.Execute(command);
        }
    }
}