#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EmailCommandHandler.cs" company="United Shore Financial Services LLC.">
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

using USFS.Core.Command;
using USFS.Domain.Me2U.Contracts.Commands;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    public class EmailCommandHandler : ICommandHandler<SendEmailCommand>
    {

        private readonly IEmailRepository emailRepository;

        private readonly ICommandBus commandBus;

        public EmailCommandHandler(IEmailRepository emailRepository, ICommandBus commandBus)
        {
            this.emailRepository = emailRepository;
            this.commandBus = commandBus;
        }
        public void HandleCommand(SendEmailCommand command)
        {
            emailRepository.SendEmail(command.Email);
        }
    }
}
