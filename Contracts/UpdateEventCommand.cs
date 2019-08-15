using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts
{
    public class UpdateEventCommand : DefaultCommand
    {
        public Event Event { get; set; }

        public UpdateEventCommand(Event @event)
        {
            Event = @event;
        }
    }
}