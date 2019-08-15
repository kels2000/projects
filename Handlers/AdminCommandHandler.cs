#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="AdminCommandHandler.cs" company="United Shore Financial Services LLC.">
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
using USFS.Core;
using USFS.Core.Command;
using USFS.Domain.Me2U.Contracts.Commands;
using USFS.Domain.Me2U.Contracts.Queries;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Enumerations;
using USFS.Domain.Me2U.Repositories;
using System.Linq;
using USFS.Domain.Me2U.Constants;

namespace USFS.Domain.Me2U.Handlers
{
    /// <summary>
    /// Handles all commands for the admin controller
    /// </summary>
    public class AdminCommandHandler : ICommandHandler<InsertTicketWinnerCommand>,
                                        ICommandHandler<UpdateEventWinsRemainingCommand>,
                                        ICommandHandler<SendNonWinnerEmailCommand>
    {
        /// <summary>
        /// The interface for the command bus
        /// </summary>
        private readonly ICommandBus commandBus;

        /// <summary>
        /// The interface for the ticket claim repository
        /// </summary>
        private readonly ITicketClaimsRepository ticketClaimRepository;

        /// <summary>
        /// The interface for the event repository
        /// </summary>
        private readonly IEventRepository eventRepository;

        /// <summary>
        /// The interface for the email repository.
        /// </summary>
        private readonly IEmailRepository emailRepository;

        /// <summary>
        /// The interface for the user repository
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Constructor for AdminCommandHandler
        /// </summary>
        /// <param name="ticketClaimRepository">the ticket claim repository interface</param>
        /// <param name="commandBus">the command bus interface</param>
        /// <param name="eventRepository">the event repository interface</param>
        /// <param name="emailRepository">the email repository</param>
        /// <param name="userRepository">the user repository</param>
        public AdminCommandHandler(ITicketClaimsRepository ticketClaimRepository, ICommandBus commandBus, IEventRepository eventRepository, IEmailRepository emailRepository, IUserRepository userRepository)
        {
            this.ticketClaimRepository = ticketClaimRepository;
            this.commandBus = commandBus;
            this.eventRepository = eventRepository;
            this.emailRepository = emailRepository;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Handler for the InsertTicketWinnerCommand
        /// </summary>
        /// <param name="command">the insertTicketWinnerCommand</param>
        public void HandleCommand (InsertTicketWinnerCommand command)
        {
            List<string> userList = command.TicketWinners.Split(',').ToList();
            if (userList != null && userList.Any())
            {
                foreach (string user in userList)
                {
                    CurrentUser winnerInformation = userRepository.SelectUser(new CurrentUser(user));
                    TicketWinner ticketWinner = new TicketWinner(winnerInformation.EmailAddress, command.EventId, user, command.UserName);
                    ticketClaimRepository.InsertTicketWinner(ticketWinner);
                }
            }
        }

        /// <summary>
        /// Handler for the UpdateEventWinsRemainingCommand
        /// </summary>
        /// <param name="command">The UpdateEventWinsRemaingCommand</param>
        public void HandleCommand (UpdateEventWinsRemainingCommand command)
        {
            if (command != null)
            {
                ticketClaimRepository.UpdateRemainingWinnersForEvent(command.Eventid, command.WinsRemaining);
            }
        }

        /// <summary>
        /// Handler for the SendNonWinnerEmailCommand
        /// </summary>
        /// <param name="command">The SendNonWinnerEmailCommand</param>
        public void HandleCommand (SendNonWinnerEmailCommand command)
        {
            List<string> nonWinners = eventRepository.GetAllNonWinnersForEvent(command.EventId);

            //Query for the email template
            EmailTemplate nonWinnerEmail = emailRepository.GetEmailTemplate(new EmailTemplate(Enumeration.TryFindById<EmailTemplateEnum>(3).DisplayValue));

            if (nonWinners != null && nonWinners.Any())
            {
                foreach (string email in nonWinners)
                {
                    nonWinnerEmail.EmailSubject = nonWinnerEmail.EmailSubject.Replace("@@EventName@@", command.EventName);

                    emailRepository.SendEmail(new Email(
                       Me2YouConstants.EmailProfile,
                        email,
                        nonWinnerEmail.EmailSubject,
                        nonWinnerEmail.EmailBody));
                }
            }
        }
    }
}
