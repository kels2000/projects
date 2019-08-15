using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Class for Insert Event Command
    /// </summary>
    public class InsertEventCommand : DefaultCommand
        {
            public Event newEvent { get; private set; }

            // <summary>
            /// InsertEventCommand constructor.
            /// </summary>
            public InsertEventCommand(Event newevent)
            {
                newEvent = newevent;
            }

        }        
}
