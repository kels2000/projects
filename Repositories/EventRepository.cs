#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EventRepository.cs" company="United Shore Financial Services LLC.">
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
using System.Linq;
using USFS.Core;
using USFS.Core.Data;
using USFS.Domain.Me2U.Constants;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Enumerations;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// Repository for methods pertaining to events.
    /// </summary>
    public class EventRepository : IEventRepository
    {
        /// <summary>
        /// the data repository
        /// </summary>
        private DataRepository db { get; set; }

        /// <summary>
        /// Constructor method for UserRepository
        /// </summary>
        /// <param name="database">the database</param>
        public EventRepository(DataRepository database)
        {
            db = database;
        }

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
        public Event InsertEvent(Event newEvent)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertEvent);
            statement.AddParameter("EventName", newEvent.EventName);
            statement.AddParameter("EventDate", newEvent.EventDate);
            statement.AddParameter("EventDescription", newEvent.EventDescription);
            statement.AddParameter("Venue", newEvent.Venue);
            statement.AddParameter("CategoryId", newEvent.CategoryId);
            statement.AddParameter("Quantity", newEvent.Quantity);
            statement.AddParameter("Claims", newEvent.Claims);
            statement.AddParameter("PostStatus", newEvent.PostStatus);
            statement.AddParameter("DatePosted", newEvent.DatePosted);
            statement.AddParameter("MaxWins", newEvent.MaxNumberOfWins);
            statement.AddParameter("TotalHandsRaised", newEvent.TotalHandsRaised);
           return db.ExecuteStoredProc(statement, EventMapper).FirstOrDefault();
        }
      

        /// <summary>
        /// Gets all the events from database the have been marked with a category id 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>All events in a certain category</returns>
        public List<EventPreview> GetAllEventsForCategory(int categoryId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllEventsForCategory);
            statement.AddParameter("CategoryId", categoryId);
            return db.ExecuteStoredProc(statement, EventPreviewMapper).ToList();
        }

        /// <summary>
        /// Gets an event based on its event id
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Event data attached to an event id</returns>
        public Event GetEventByEventId(int eventId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetEventByEventId);
            statement.AddParameter("EventId", eventId);
            return db.ExecuteStoredProc(statement, EventMapper).FirstOrDefault();
        }

        /// <summary>
        /// Gets photos from the picture table for an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Image path and event id</returns>
        public List<Picture> GetEventPostPictures(int eventId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetEventPostPictures);
            statement.AddParameter("EventId", eventId);
            return db.ExecuteStoredProc(statement, PictureMapper).ToList();
        }

        /// <summary>
        /// Insert pictures for an event
        /// </summary>
        /// <param name="picture"></param>
        /// <returns>The new picture object that was created</returns>
        public Picture InsertPicture(Picture picture)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertPicture);
            statement.AddParameter("PostId", picture.PostId);
            statement.AddParameter("EventId", picture.EventId);
            statement.AddParameter("PictureImagePath", picture.PictureImagePath);
            return db.ExecuteStoredProc(statement, PictureMapper).FirstOrDefault();
        }

        /// <summary>
        /// Gets event previews to populate the carousel on the ticket hub home page 
        /// </summary>
        /// <returns>List of the 12 most recent events created with a photo</returns>
        public List<EventPreview> GetAllEventsForCarousel()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllEventsForCarousel);
            return db.ExecuteStoredProc(statement, EventPreviewMapper).ToList();
        }


        /// <summary>
        /// Gets all events in database -- no matter what status it is in
        /// </summary>
        /// <returns>A list of events</returns>
        public List<Event> GetAllEvents()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllEvents);
            return db.ExecuteStoredProc(statement, EventMapper).ToList();
        }

        /// <summary>
        /// Gets all of the currently active events.
        /// </summary>
        /// <returns>a list of all of the active events.</returns>
        public List<Event> GetAllActiveEvents()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllActiveEvents);
            return db.ExecuteStoredProc(statement, EventMapper).ToList();
        }

        /// <summary>
        /// Updates event info for when an admin edits
        /// </summary>
        /// <param name="event"></param>
        /// <returns>The updated event</returns>
        public Event UpdateEvent(Event @event)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpdateEvent);
            statement.AddParameter("EventId", @event.EventId);
            statement.AddParameter("Venue", @event.Venue);
            statement.AddParameter("EventDescription", @event.EventDescription);
            statement.AddParameter("EventName", @event.EventName);
            statement.AddParameter("EventDate", @event.EventDate);
            statement.AddParameter("CategoryId", Enumeration.TryFindById<TicketCategoryEnum>(@event.CategoryId.Id));            
            statement.AddParameter("Quantity", @event.Quantity);
            statement.AddParameter("Claims", @event.Claims);
            statement.AddParameter("PostStatus", @event.PostStatus);
            statement.AddParameter("DatePosted", @event.DatePosted);
            statement.AddParameter("MaxWins", @event.MaxNumberOfWins);
            statement.AddParameter("WinsRemaining", @event.WinsRemaining);
            return db.ExecuteStoredProc(statement, EventMapper).FirstOrDefault();
        }
        
        /// <summary>
        /// Joins ticket claim table with events table to access the count of claims for each event
        /// </summary>
        /// <returns>A list of events</returns>
        public List<Event> GetTicketClaimCountForEvent()
        {   SqlStatement statement = new SqlStatement(StoredProcedures.GetTicketClaimCountForEvent);
            return db.ExecuteStoredProc(statement, EventMapper).ToList();
        }

        /// <summary>
        /// Updates the status of an event post based its id
        /// </summary>
        /// <param name="postStatus"></param>
        /// <param name="eventId"></param>
        public void UpdateEventPostStatus(int postStatus, int eventId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpdateEventPostStatus);
            statement.AddParameter("EventId", eventId);
            statement.AddParameter("PostStatus", postStatus);
            db.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Gets all of the winners for an event.
        /// </summary>
        /// <param name="eventId">the id of the event</param>
        /// <returns>a list of UserNames of the ticket winners for this event.</returns>
        public List<string> GetAllWinnersForEvent(int eventId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllWinnersForEvent);
            statement.AddParameter("eventId", eventId);
            return db.ExecuteStoredProc(statement, MapGetAllWinnersForEvent).ToList();
        }

        /// <summary>
        /// Gets all of the non-winners for an event. (the individuals who have raised their hand but have not won.)
        /// </summary>
        /// <param name="eventId">the id of the event</param>
        /// <returns>A list of email addresses for all of the non-winners for an event.</returns>
        public List<string> GetAllNonWinnersForEvent(int eventId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllNonWinnersForEvent);
            statement.AddParameter("eventId", eventId);
            return db.ExecuteStoredProc(statement, MapGetAllNonWinnersForEvent).ToList();
        }

        //-------------------------------------------OBJECT MAPPERS-------------------------------------------
        /// <summary>
        /// Map the event preview object from the database 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rownum"></param>
        /// <returns>Event preview object</returns>
        private EventPreview EventPreviewMapper(SqlReaderWrapper data, int rownum)
        {
            return new EventPreview(data.GetInt("EventId"),
                                    data.GetString("EventName"),
                                    data.GetDate("EventDate"),
                                    data.GetString("Pictures"));
        }
        
      /// <summary>
      /// Maps event object from database 
      /// </summary>
      /// <param name="data"></param>
      /// <param name="rownum"></param>
      /// <returns>An event object</returns>
        private Event EventMapper(SqlReaderWrapper data, int rownum)
        {
            return new Event(data.GetInt("EventId"),
                             data.GetString("Venue"),
                             data.GetString("EventDescription"),
                             data.GetString("EventName"), 
                             data.GetDate("EventDate"),
                             Enumeration.TryFindById<TicketCategoryEnum>(data.GetInt("CategoryId")),
                             data.GetInt("Quantity"), 
                             data.GetInt("Claims"), 
                             Enumeration.TryFindById<TicketPostStatusEnum>(data.GetInt("PostStatus")),
                             data.GetDate("DatePosted"),
                             data.GetInt("TotalHandsRaised"),
                             data.GetInt("MaxNumberOfWins"),
                             data.GetInt("WinsRemaining"));

        }

        /// <summary>
        /// Maps the picture object from the database
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rownum"></param>
        /// <returns>A picture object</returns>
        private Picture PictureMapper(SqlReaderWrapper data, int rownum)
        {
            return new Picture(data.GetInt("PostId"),
                               data.GetString("PictureImagePath"),
                               data.GetInt("EventId"));
        }

        /// <summary>
        /// Maps the data returned from the database to an object
        /// </summary>
        /// <param name="data">the data returned from the database</param>
        /// <param name="row">the row number of the data</param>
        /// <returns>The data from the database row mapped to an object</returns>
        private string MapGetAllWinnersForEvent(SqlReaderWrapper data, int row)
        {
            string winnerEmail = data.GetString("WinnerUserName");
            return winnerEmail;
        }

        /// <summary>
        /// Maps a row from the database to an object
        /// </summary>
        /// <param name="data">the data from a row in sthe database.</param>
        /// <param name="row">the row numbero of the data</param>
        /// <returns>the email address of one of the non-winners</returns>
        private string MapGetAllNonWinnersForEvent(SqlReaderWrapper data, int row)
        {
            string nonWinner = data.GetString("EmailAddress");
            return nonWinner;
        }
    }
}