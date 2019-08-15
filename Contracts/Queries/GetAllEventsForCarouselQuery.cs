using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Class for Query to get All Event Preview Objects to Populate Ticket Hub Carousel
    /// </summary>
    public class GetAllEventsForCarouselQuery : IQuery<List<EventPreview>>
    {
        
    }
}