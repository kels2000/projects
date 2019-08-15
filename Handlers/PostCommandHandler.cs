#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="PostCommandHandler.cs" company="United Shore Financial Services LLC.">
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
using USFS.Domain.Me2U.Contracts.Commands;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    /// <summary>
    /// Contains the handlers for post commands.
    /// </summary>
    public class PostCommandHandler : ICommandHandler<InsertPostCommand>, ICommandHandler<InsertPictureCommand>, ICommandHandler<UpdatePostCommand>, 
                                        ICommandHandler<RemovePhotoCommand>, ICommandHandler<InsertPostClaimCommand>, ICommandHandler<CheckAllPostsForExpirationDateCommand>,
                                        ICommandHandler<UpdatePostToDeliveredCommand>, ICommandHandler<RemovePostCommand>, ICommandHandler<UpdatePostToActiveCommand>
    {
        /// <summary>
        /// The post repository, holds methods for accessing the database
        /// </summary>
        private readonly IPostRepository postRepository;

        /// <summary>
        /// the command bus, used as abstraction between the UI and domain layer
        /// </summary>
        private readonly ICommandBus commandBus;

        /// <summary>
        /// Constructor for PostCommandHandler
        /// </summary>
        /// <param name="postRepository">the post repository</param>
        /// <param name="commandBus">the command bus</param>
        public PostCommandHandler(IPostRepository postRepository, ICommandBus commandBus)
        {
            this.postRepository = postRepository;
            this.commandBus = commandBus;
        }

        /// <summary>
        /// Handler for the InserPostCommand command
        /// </summary>
        /// <param name="command">the InsertPost Command</param>
        public void HandleCommand(InsertPostCommand command)
        {
            Post post = postRepository.InsertPost(command.Post);
            commandBus.Reply(command.Identity, post);
        }

        /// <summary>
        /// Handler for the InsertPictureCommand command
        /// </summary>
        /// <param name="command">the InsertPicture Command</param>
        public void HandleCommand(InsertPictureCommand command)
        {
            postRepository.InsertPicture(command.Picture);
        }

        /// <summary>
        /// Handler for the UpdatePostCommand command
        /// </summary>
        /// <param name="command">The UpdatePost Command</param>
        public void HandleCommand(UpdatePostCommand command)
        {
            postRepository.UpdatePost(command.Post);
        }

        /// <summary>
        /// Handler for the RemovePhotoCommand command
        /// </summary>
        /// <param name="command">the RemovePhoto Command</param>
        public void HandleCommand(RemovePhotoCommand command)
        {
            List<Picture> listPics = postRepository.RemovePicture(command.Picture);
            commandBus.Reply(command.Identity, listPics);
        }

        /// <summary>
        /// Handler for the InsertPostClaimCommand command
        /// </summary>
        /// <param name="command">the InsertPostClaim Command</param>
        public void HandleCommand(InsertPostClaimCommand command)
        {
            postRepository.InsertPostClaim(command.PostClaim);
        }

        /// <summary>
        /// Handler for the CheckAllPostsForExpirationDateCommand command
        /// </summary>
        /// <param name="command">the CheckAllPostForExirationDate Command</param>
        public void HandleCommand(CheckAllPostsForExpirationDateCommand command)
        {
            postRepository.CheckAllPostsForExpirationDate();
        }

        /// <summary>
        /// Handler for the UpdatePostToDeliveredCommand command
        /// </summary>
        /// <param name="command">the UpdatePostToDelivered Command</param>
        public void HandleCommand(UpdatePostToDeliveredCommand command)
        {
            postRepository.UpdatePostToDelivered(command.Post, command.UserName);
        }

        /// <summary>
        /// Handler for the RemovePostCommand command
        /// </summary>
        /// <param name="command">the RemovePost Command</param>
        public void HandleCommand(RemovePostCommand command)
        {
            postRepository.RemovePost(command.Post, command.UserName);
        }

        /// <summary>
        /// Updates a post to active and updates the expiration date.
        /// </summary>
        /// <param name="command">the UpdatePostToActive command</param>
        public void HandleCommand(UpdatePostToActiveCommand command)
        {
            postRepository.UpdatePostToActiveAndUpdateExpirationDate(command.PostId, command.ExpirationDate, command.UserName);
        }
    }
}
