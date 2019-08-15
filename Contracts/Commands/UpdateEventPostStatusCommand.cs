using USFS.Core.Command;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Command to update the status of an event 
    /// </summary>
    public class UpdateEventPostStatusCommand : DefaultCommand
    {
        public int EventId { get; set; }

        public int PostStatus { get; set; }

        public UpdateEventPostStatusCommand(int eventId, int postStatus)
        {
            EventId = eventId;
            PostStatus = postStatus;
        }
    }
}