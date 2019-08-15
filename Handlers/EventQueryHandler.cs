#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EventQueryHandler.cs" company="United Shore Financial Services LLC.">
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
using USFS.Core.Command;
using USFS.Domain.Me2U.Contracts.Queries;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    /// <summary>
    /// Class to handle querys for the event page.
    /// </summary>
    public class EventQueryHandler : 
                                     IQueryHandler<GetAllEventsForCategory, List<EventPreview>>,
                                     IQueryHandler<GetEventByEventId, Event>,
                                     IQueryHandler<GetEventPostPictures, List<Picture>>,
                                     IQueryHandler<GetTicketClaimsByEventIdQuery, List<TicketClaims>>,
                                     IQueryHandler<GetAllEventsForCarouselQuery, List<EventPreview>>,
                                     IQueryHandler<GetAllEventsQuery, List<Event>>,
                                     IQueryHandler<GetTicketClaimCountForEventQuery, List<Event>>,
                                     IQueryHandler<GetAllActiveEventsQuery, List<Event>>,
                                     IQueryHandler<GetAllWinnersForEventQuery, List<string>>,
                                     IQueryHandler<GetAllNonWinnersForEventQuery, List<string>>

    {
        /// <summary>
        /// interface for the event repository
        /// </summary>
        private readonly IEventRepository eventRepository;

        /// <summary>
        /// interface for the ticket claim claims repository
        /// </summary>
        private readonly ITicketClaimsRepository ticketClaimClaimsRepository;

        /// <summary>
        /// constructor for event query handler
        /// </summary>
        /// <param name="eventRepository">the interface for the event repository</param>
        /// <param name="ticketClaimClaimsRepository">the interface for the ticket claim claims repository</param>
        public EventQueryHandler(IEventRepository eventRepository, ITicketClaimsRepository ticketClaimClaimsRepository)
        {
            this.eventRepository = eventRepository;
            this.ticketClaimClaimsRepository = ticketClaimClaimsRepository;
        }

        /// <summary>
        /// handler for the get all events for category query
        /// </summary>
        /// <param name="query">the get all events for category query</param>
        /// <returns>All events for a category.</returns>
        public List<EventPreview> Handle(GetAllEventsForCategory query)
        {
            return eventRepository.GetAllEventsForCategory(query.CategoryId);
        }

        /// <summary>
        /// Handler for the get event by event id query
        /// </summary>
        /// <param name="query">the get event by event id query</param>
        /// <returns>an event</returns>
        public Event Handle(GetEventByEventId query)
        {
            return eventRepository.GetEventByEventId(query.EventId);
        }

        /// <summary>
        /// Handler for get event post pictures
        /// </summary>
        /// <param name="query">the get event post pictures query</param>
        /// <returns>the pictures for the associated event</returns>
        public List<Picture> Handle(GetEventPostPictures query)
        {
            return eventRepository.GetEventPostPictures(query.EventId);
        }

        /// <summary>
        /// Handler for the GetticketClaimsByEventIdQuery
        /// </summary>
        /// <param name="query">The GetTicketClaimsByEventIdQuery</param>
        /// <returns>the information retrieved from the database.</returns>
        public List<TicketClaims> Handle(GetTicketClaimsByEventIdQuery query)
        {
            List<TicketClaims> claims = ticketClaimClaimsRepository.GetTicketClaimsByEventId(query.EventId);
            return claims;
        }

        /// <summary>
        /// Handler for the get all events for carousel query
        /// </summary>
        /// <param name="query">the get allevents for carousel query</param>
        /// <returns>the events that will be displayed in the ticket page carousel</returns>
        public List<EventPreview> Handle(GetAllEventsForCarouselQuery query)
        {
            return eventRepository.GetAllEventsForCarousel();
        }

        /// <summary>
        /// Handler for the get ticket claim count for event query
        /// </summary>
        /// <param name="query">the get ticket claim count for event query</param>
        /// <returns>the total number of ticket claims for an event.</returns>
        public List<Event> Handle(GetTicketClaimCountForEventQuery query)
        {
            return eventRepository.GetTicketClaimCountForEvent();
        }

        /// <summary>
        /// Handler for the get all events query.
        /// </summary>
        /// <param name="query">the get all events query</param>
        /// <returns>all events (active and otherwise)</returns>
        public List<Event> Handle(GetAllEventsQuery query)
        {
            return eventRepository.GetAllEvents();
        }

        /// <summary>
        /// Handler for the get all active events query.
        /// </summary>
        /// <param name="query">the ge tall active events query</param>
        /// <returns>all active events</returns>
        public List<Event> Handle(GetAllActiveEventsQuery query)
        {
            return eventRepository.GetAllActiveEvents();
        }

        /// <summary>
        /// Handler for the get all non-winners for event query.
        /// </summary>
        /// <param name="query">the get all non-winners for event query</param>
        /// <returns>a list of emails for all individuals who raised their hand for an event but were not chosen.</returns>
        public List<string> Handle(GetAllNonWinnersForEventQuery query)
        {
            return eventRepository.GetAllNonWinnersForEvent(query.EventId);
        }

        /// <summary>
        /// Handler for ge tall winners for event query
        /// </summary>
        /// <param name="query">the get all winners for event query</param>
        /// <returns>a list of all individuals who were chosen to recieve tickets for an event.</returns>
        public List<string> Handle(GetAllWinnersForEventQuery query)
        {
            return eventRepository.GetAllWinnersForEvent(query.EventId);
        }
    }
}