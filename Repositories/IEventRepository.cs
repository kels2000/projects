#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="IEventRepository.cs" company="United Shore Financial Services LLC.">
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

using System.Collections.Generic;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// the interface for the event repository
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// Inserts a  new event object into the database
        /// </summary>
        /// <param name="newEvent.EventName">The event name</param>
        /// <param name="newEvent.EventDate">The event date</param>
        /// <param name="newEvent.EventDescription">The event description</param> 
        /// <param name="newEvent.EventVenue">The venue of the event</param>  
        /// <param name="newEvent.CategoryId">The category of the event</param>
        /// <param name="newEvent.Quantity">The total number of tickets TMS has to give out for the event</param>
        /// <param name="newEvent.Claims">The maximum number of tickets winners will receive</param>    
        /// <param name="newEvent.PostStatus ">Marks new event as active and tracks it's status later</param>
        /// <param name="newEvent.DatePosted">Time stamp for when the event was created</param>  
        /// <returns>The newly inserted event</returns>
        Event InsertEvent(Event newEvent);

        /// <summary>
        /// Gets all the events from database the have been marked with a category id 
        /// </summary>
        /// <param name="categoryId">the id of the category to get events</param>
        /// <returns>All events in a certain category</returns>
        List<EventPreview> GetAllEventsForCategory(int categoryId);

        /// <summary>
        /// Gets an event based on its event id
        /// </summary>
        /// <param name="eventId">the id of the event to get</param>
        /// <returns>Event data attached to an event id</returns>
        Event GetEventByEventId(int eventId);

        /// <summary>
        /// Gets photos from the picture table for an event
        /// </summary>
        /// <param name="eventId">the id of the event to get images for</param>
        /// <returns>Image path and event id</returns>
        List<Picture> GetEventPostPictures(int eventId);

        /// <summary>
        /// Gets event previews to populate the carousel on the ticket hub home page 
        /// </summary>
        /// <returns>List of the 12 most recent events created with a photo</returns>
        List<EventPreview> GetAllEventsForCarousel();

        /// <summary>
        /// Updates event info for when an admin edits
        /// </summary>
        /// <param name="event">the event to update</param>
        /// <returns>The updated event</returns>
        Event UpdateEvent(Event @event);

        /// <summary>
        /// Gets all events in database -- no matter what status it is in
        /// </summary>
        /// <returns>A list of events</returns>
        List<Event> GetAllEvents();

        /// <summary>
        /// Gets all of the currently active events.
        /// </summary>
        /// <returns>a list of all of the active events.</returns>
        List<Event> GetAllActiveEvents();

        /// <summary>
        /// Joins ticket claim table with events table to access the count of claims for each event
        /// </summary>
        /// <returns>A list of events</returns>
        List<Event> GetTicketClaimCountForEvent();

        /// <summary>
        /// Updates the status of an event post based on its id
        /// </summary>
        /// <param name="postStatus">the status to update an event to</param>
        /// <param name="eventId">the id of the evnet to update</param>
        void UpdateEventPostStatus(int postStatus, int eventId);

        /// <summary>
        /// Gets all of the winners for an event.
        /// </summary>
        /// <param name="eventId">the id of the event</param>
        /// <returns>a list of email addresses of the ticket winners for this event.</returns>
        List<string> GetAllWinnersForEvent(int eventId);

        /// <summary>
        /// Gets all of the non-winners for an event. (the individuals who have raised their hand but have not won.)
        /// </summary>
        /// <param name="eventId">The id of the event</param>
        /// <returns>A list of email addresses for all of the non-winners for an event.</returns>
        List<string> GetAllNonWinnersForEvent(int eventId);
    }
}