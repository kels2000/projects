using USFS.Core.Command;
using USFS.Domain.Me2U.Contracts;
using USFS.Domain.Me2U.Contracts.Commands;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    public class EventCommandHandler :  ICommandHandler<InsertEventCommand>,
                                        ICommandHandler<InsertTicketClaim>,
                                        ICommandHandler<UpdateEventCommand>,
                                        ICommandHandler<UpdateEventPostStatusCommand>
    {

        private readonly IEventRepository eventRepository;
        private readonly ITicketClaimsRepository ticketClaimsRepository;
        private readonly ICommandBus commandBus;

        public EventCommandHandler(IEventRepository eventRepository, ICommandBus commandBus, ITicketClaimsRepository ticketClaimsRepository)
        {
            this.eventRepository = eventRepository;
            this.commandBus = commandBus;
            this.ticketClaimsRepository = ticketClaimsRepository;
        }

        public void HandleCommand(InsertEventCommand command)
        {
            Event newEvent = eventRepository.InsertEvent(command.newEvent);
            commandBus.Reply(command.Identity, newEvent);
        }

        public void HandleCommand(InsertTicketClaim command)
        {
            ticketClaimsRepository.InsertTicketClaim(command.TicketClaim);

        }

        public void HandleCommand(UpdateEventCommand command)
        {
            eventRepository.UpdateEvent(command.Event);
        }

        public void HandleCommand(UpdateEventPostStatusCommand command)
        {
            eventRepository.UpdateEventPostStatus(command.PostStatus, command.EventId);
           
        }


    }
}