using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Class for Updating/Editing an Event Command
    /// </summary>
    public class UpdateEventCommand : DefaultCommand
    {
        public Event Event { get; set; }

        /// <summary>
        /// Update an Event Command Constructor
        /// </summary>
        public UpdateEventCommand(Event @event)
        {
            Event = @event;
        }
    }
}