using System;

namespace USFS.Domain.Me2U.DTO
{
    public class EventPreview
    {
        /// <summary>
        /// Database ID of Event 
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Database Event Name 
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Database File Path of a Photo Attached to EventId
        /// </summary>
        public string PictureImagePath { get; set; }

        /// <summary>
        /// Database Value for the Event Date 
        /// </summary>
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Event Preview Empty Constructor
        /// </summary>
        public EventPreview()
        {
            
        }

        /// <summary>
        /// Event Preview Constructor
        /// </summary>
        public EventPreview(int eventId, string eventName, DateTime eventDate, string pictureImagePath)
        {
            EventId = eventId;
            EventName = eventName;
            EventDate = eventDate;
            PictureImagePath = pictureImagePath;
        }
    }
}