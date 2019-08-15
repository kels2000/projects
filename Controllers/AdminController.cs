#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="AdminController.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using USFS.Core;
    using USFS.Core.Command;
    using USFS.Domain.Me2U.Constants;
    using USFS.Domain.Me2U.Contracts.Commands;
    using USFS.Domain.Me2U.Contracts.Queries;
    using USFS.Domain.Me2U.DTO;
    using USFS.Domain.Me2U.Enumerations;
    using USFS.WebUI.Me2U.Constants;
    using USFS.WebUI.Me2U.Helpers;
    using USFS.WebUI.Me2U.Models;

    /// <summary>
    /// Controller for the admin view.
    /// </summary>
    [Authorize]
    public class AdminController : Controller
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
        /// Constructor for admin controller
        /// </summary>
        /// <param name="commandBus">the command bus</param>
        /// <param name="claimsHelper">the claims helper</param>
        /// <param name="loggingHelper">the logging helper</param>
        public AdminController(ICommandBus commandBus, IClaimsHelper claimsHelper, ILoggingHelper loggingHelper)
        {
            this.commandBus = commandBus;
            this.claimsHelper = claimsHelper;
            this.loggingHelper = loggingHelper;
        }
        /// <summary>
        /// Populates the admin model to open the admin portal if you are an admin 
        /// </summary>
        /// <returns>Admin Home Page View with empty model</returns>
        public ActionResult Index()
        {
            AdminModel model = new AdminModel();

            if (!AllowAccess())
            {
                return View(ViewNames.FailedToAuthenticate);
            }

            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);
            return View(ViewNames.AdminHomePage, model);
        }

        /// <summary>
        /// Return Create New Event Form
        /// </summary>
        /// <returns>create event post view, logout page if not allowed</returns>
        public ActionResult CreateNewEvent()
        {

            AdminModel model = new AdminModel();
            if (!AllowAccess())
            {
                return View(ViewNames.FailedToAuthenticate);
            }

            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);
            return View(ViewNames.CreateEventPost, model);
        }

        /// <summary>
        /// Repopulates Admin Model to show up to date ticket claims table
        /// </summary>
        /// <returns>ticket claims partial view with list of events</returns>
        public ActionResult TicketClaims()
        {
            AdminModel model = new AdminModel();
            GetTicketClaimCountForEventQuery eventsQuery = new GetTicketClaimCountForEventQuery();
            model.Events = commandBus.ProcessQuery(eventsQuery);

            return PartialView(ViewNames.TicketClaims, model);
        }

        /// <summary>
        /// Repopulates Admin Model to show up to date update events table
        /// </summary>
        /// <returns>update events partial view with list of events</returns>
        public ActionResult UpdateEvents()
        {
            AdminModel model = new AdminModel();

            GetTicketClaimCountForEventQuery eventsQuery = new GetTicketClaimCountForEventQuery();
            model.Events = commandBus.ProcessQuery(eventsQuery);

            return PartialView(ViewNames.UpdateEvents, model);
        }

        /// <summary>
        /// Saves a new event that was created from form data
        /// </summary>
        /// <returns>The new event info</returns>
        [HttpPost]
        public Event SaveEvent()
        {
            string category = Request.Form.Get("Event.CategoryId.Id");
            string eventVenue = Request.Form.Get("Event.Venue");
            string eventName = Request.Form.Get("Event.EventName");
            string eventDate = Request.Form.Get("Event.EventDate");
            string ticketQuantity = Request.Form.Get("Event.Quantity");
            string maxClaims = Request.Form.Get("Event.Claims");
            string eventDescription = Request.Form.Get("Event.EventDescription");
            string eventId = Request.Form.Get("Event.EventId");


            DateTime enteredDate = DateTime.Parse(eventDate);
            DateTime datePosted = DateTime.Now;
            int enteredTicketQuantity = int.Parse(ticketQuantity);
            int categoryId = int.Parse(category);
            int enteredMaxClaims = int.Parse(maxClaims);
            int postStatus = 1;
            int totalHandsRaised = 0;
            int maxWinners = Convert.ToInt32(Math.Floor(Convert.ToDecimal((enteredTicketQuantity / enteredMaxClaims))));
            int remainingWinners = maxWinners;

            if (eventId != "")
            {
                int updateEventId = int.Parse(eventId);

                Event updateEvent = ConvertToEvent(eventVenue, eventName, enteredDate, enteredTicketQuantity, enteredMaxClaims,
                                                    categoryId, datePosted, postStatus, eventDescription, totalHandsRaised, maxWinners, remainingWinners);
                updateEvent.EventId = updateEventId;

                UpdateEventCommand updateCommand = new UpdateEventCommand(updateEvent);
                commandBus.Execute(updateCommand);


                List<String> updateImagePaths = ImagePathCreation();

                foreach (string path in updateImagePaths)
                {
                    InsertPictureCommand eventCommand = new InsertPictureCommand(new Picture(0, path, updateEvent.EventId));
                    commandBus.Execute(eventCommand);
                }

                return updateEvent;
            }

            Event newEvent = ConvertToEvent(eventVenue, eventName, enteredDate, enteredTicketQuantity, enteredMaxClaims, categoryId,
                                            datePosted, postStatus, eventDescription, totalHandsRaised, maxWinners, remainingWinners);
            InsertEventCommand command = new InsertEventCommand(newEvent);
            commandBus.Execute(command, delegate (Event result) { newEvent = result; });

            List<String> imagePaths = ImagePathCreation();

            foreach (string path in imagePaths)
            {
                InsertPictureCommand eventCommand = new InsertPictureCommand(new Picture(0, path, newEvent.EventId));
                commandBus.Execute(eventCommand);
            }

            return newEvent;
        }

        /// <summary>
        /// Pre-populates the create new event form to edit an event based on its event id 
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Create new event form</returns>
        public ActionResult EditEventDetails(int eventId)
        {
            AdminModel model = new AdminModel();

            if (!AllowAccess())
            {
                return View(ViewNames.FailedToAuthenticate);
            }

            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);
            GetEventByEventId eventQuery = new GetEventByEventId(eventId);
            model.Event = commandBus.ProcessQuery(eventQuery);

            IEnumerable<TicketCategoryEnum> categoryEnum = Enumeration.GetAll<TicketCategoryEnum>().ToList();
            IEnumerable<SelectListItem> categoryList = categoryEnum.Select(item => new SelectListItem()
            {
                Text = item.DisplayValue,
                Value = item.Id,
                Selected = item.Id.Equals(model.Event.CategoryId.Id)
            });
            model.EventCategories = new SelectList(categoryEnum);

            GetEventPostPictures pictureQuery = new GetEventPostPictures(eventId);
            model.Pictures = commandBus.ProcessQuery(pictureQuery);

            GetTicketClaimsByEventIdQuery ticketClaimQuery = new GetTicketClaimsByEventIdQuery(eventId);
            model.TicketClaims = commandBus.ProcessQuery(ticketClaimQuery);

            GetAllEventsQuery activeEvents = new GetAllEventsQuery();
            model.Events = commandBus.ProcessQuery(activeEvents);

            return View(ViewNames.AdminHomePage, model);
        }

        /// <summary>
        /// Gets list of team members who were interested in an event for the admin to see
        /// </summary>
        /// <param name="eventId">the id of the event to load ticket view for</param>
        /// <returns>Ticket claims info for an event</returns>
        public ActionResult LoadTicketGiveAwayView(int eventId)
        {
            AdminModel model = new AdminModel();

            if (!AllowAccess())
            {
                return View(ViewNames.FailedToAuthenticate);
            }

            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);
            GetEventByEventId eventQuery = new GetEventByEventId(eventId);
            model.Event = commandBus.ProcessQuery(eventQuery);

            GetAllWinnersForEventQuery winnersQuery = new GetAllWinnersForEventQuery(eventId);
            model.Event.WinnersForEvent = commandBus.ProcessQuery(winnersQuery);

            GetAllNonWinnersForEventQuery nonWinnersQuery = new GetAllNonWinnersForEventQuery(eventId);
            model.Event.NonWinnersForEvent = commandBus.ProcessQuery(nonWinnersQuery);

            GetTicketClaimsByEventIdQuery ticketClaimQuery = new GetTicketClaimsByEventIdQuery(eventId);
            model.TicketClaims = commandBus.ProcessQuery(ticketClaimQuery);

            return View(ViewNames.SelectTicketWinner, model);
        }

        /// <summary>
        /// Inserts the winners into the ticket winner table and sends them an email.
        /// </summary>
        /// <param name="winners">a comma separated string of the usernames of ticket winners</param>
        /// <param name="eventId">the id of the event we are giving away tickets for</param>
        public void SubmitWinners(string winners, int eventId, string eventName)
        {
            SelectUserQuery currentUser = new SelectUserQuery(new CurrentUser(claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity)));
            CurrentUser user = commandBus.ProcessQuery(currentUser);

            InsertTicketWinnerCommand insertWinner = new InsertTicketWinnerCommand(winners, eventId, user.LoginName);
            commandBus.Execute(insertWinner);

            //Query for the email template
            GetEmailTemplateQuery query = new GetEmailTemplateQuery(new EmailTemplate(Enumeration.TryFindById<EmailTemplateEnum>(4).DisplayValue));
            EmailTemplate winnerEmail = commandBus.ProcessQuery(query);

            winnerEmail.EmailBody = winnerEmail.EmailBody.Replace("@@EventName@@", eventName);
            winnerEmail.EmailSubject = winnerEmail.EmailSubject.Replace("@@EventName@@", eventName);

            List<string> winnerList = winners.Split(',').ToList();
            if (winnerList != null && winnerList.Any())
            {
                foreach (string winner in winnerList)
                {
                    SelectUserQuery winnerInformationQuery = new SelectUserQuery(new CurrentUser(winner));
                    CurrentUser winnerInformation = commandBus.ProcessQuery(winnerInformationQuery);
                    SendEmailCommand emailCommand = new SendEmailCommand(new Email(
                       Me2YouConstants.EmailProfile,
                        winnerInformation.EmailAddress,
                        winnerEmail.EmailSubject,
                        winnerEmail.EmailBody));
                    commandBus.Execute(emailCommand);
                }
            }
        }

        /// <summary>
        /// updates the number of remaining winners for an event.
        /// </summary>
        /// <param name="numberOfWinners">the number of individuals remaining that can win tickets.</param>
        /// <param name="eventId">the id of the event we are updating the winners for</param>
        public void UpdateEventWinRemainingCount(int eventId, int numberOfWinners)
        {
            UpdateEventWinsRemainingCommand updateWinner = new UpdateEventWinsRemainingCommand(eventId, numberOfWinners);
            commandBus.Execute(updateWinner);
        }

        /// <summary>
        /// Sends an email to each individual who has not won tickets for an event.
        /// <param name="eventId">the id of the event to send the emails for</param>
        /// <param name="eventName">the name of the event to send emails for</param>
        /// </summary>
        public void SendNonWinnerEmail(int eventId, string eventName)
        {
            SendNonWinnerEmailCommand nonWinnerEmailCommand = new SendNonWinnerEmailCommand(eventId, eventName);
            commandBus.Execute(nonWinnerEmailCommand);
        }

        /// <summary>
        /// store changed event status 
        /// </summary>
        /// <param name="eventId">the id of the event we are updating</param>
        /// <param name="postStatus">the new post status</param>
        public void UpdateEventPostStatus(int eventId, int postStatus)
        {
            UpdateEventPostStatusCommand command = new UpdateEventPostStatusCommand(eventId, postStatus);
            commandBus.Execute(command);
        }

        /// <summary>
        /// Create a guid for the newly uploaded file
        /// </summary>
        /// <returns>A string of the unique file name</returns>
        private string CreateGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Replace("{", "").Replace("}", "");
        }

        /// <summary>
        /// Converts post data into an event object
        /// </summary>
        /// <param name="eventVenue">Where the event is taking place</param>
        /// <param name="eventName">the name of the event</param>
        /// <param name="enteredDate">the date when the evnet is taking place</param>
        /// <param name="enteredTicketQuantity">the number of tickets</param>
        /// <param name="enteredMaxClaims">the number of tickets distributed per winner</param>
        /// <param name="categoryId">the category that the event belongs to</param>
        /// <param name="datePosted">the date the event was posted</param>
        /// <param name="postStatus">the status of the post</param>
        /// <param name="eventDescription">the description of the event</param>
        /// <param name="totalHandsRaised">the total number of users who have raised their hand for the event.</param>
        /// <returns>An event object</returns>
        private Event ConvertToEvent(string eventVenue, string eventName, DateTime enteredDate,
            int enteredTicketQuantity, int enteredMaxClaims, int categoryId,
                        DateTime datePosted, int postStatus, string eventDescription, int totalHandsRaised, int maxWinners, int remainingWinners)
        {
            Event newEvent = new Event()
            {
                EventDate = enteredDate,
                Venue = eventVenue,
                EventName = eventName,
                Quantity = enteredTicketQuantity,
                Claims = enteredMaxClaims,
                CategoryId = Enumeration.TryFindById<TicketCategoryEnum>(categoryId),
                DatePosted = datePosted,
                PostStatus = Enumeration.TryFindById<TicketPostStatusEnum>(postStatus),
                EventDescription = eventDescription,
                TotalHandsRaised = totalHandsRaised,
                MaxNumberOfWins = maxWinners,
                WinsRemaining = remainingWinners
            };
            return newEvent;
        }

        /// <summary>
        /// Stores a photo on the server and brings back the file path 
        /// </summary>
        /// <returns>A list of file paths</returns>
        private List<string> ImagePathCreation()
        {
            List<String> listOfFiles = new List<String>();
            bool isSavedSuccessfully = true;
            try
            {
                if (Request.Files.Count > 0)
                {
                    foreach (string fileName in Request.Files)
                    {
                        //Save file content goes here                    
                        HttpPostedFileBase file = Request.Files[fileName];
                        var uniqueFilename = CreateGuid();

                        if (file != null && file.ContentLength > 0)
                        {

                            var filename = Path.GetFileName(file.FileName);

                            uniqueFilename += Path.GetExtension(filename);

                            string path = ImageHelper.GetPathFromConfig(uniqueFilename);

                            file.SaveAs(path);
                            listOfFiles.Add(path);
                        }

                    }
                }

            }
            catch (Exception)
            {
                isSavedSuccessfully = false;
            }

            if (isSavedSuccessfully)
            {
                return listOfFiles;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Does the user have permission to access the admin settings
        /// </summary>
        /// <returns></returns>
        private bool AllowAccess()
        {
            if (!claimsHelper.IsUserAdmin((ClaimsIdentity)User.Identity))
            {
                loggingHelper.LogAuthenticateError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity));
                return false;
            }

            return true;
        }
    }
}