#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="UpdatePostToActiveCommand.cs" company="United Shore Financial Services LLC.">
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

using System;
using USFS.Core.Command;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Command to change a post from the delivered status to active
    /// </summary>
    public class UpdatePostToActiveCommand : DefaultCommand
    {
        /// <summary>
        /// the id of the post to update
        /// </summary>
        public int PostId { get; private set; }

        /// <summary>
        /// The date in which an active post will automatically go inactive.
        /// </summary>
        public DateTime ExpirationDate { get; private set; }

        /// <summary>
        /// The username of the individual who initaged the repost
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// The constructor for UpdatePostToActive Command
        /// </summary>
        /// <param name="expirationDate">The date when the post expires</param>
        /// <param name="postId">the id of the post to set to active</param>
        /// <param name="userName">The username of the individual who initiated the repost</param>
        public UpdatePostToActiveCommand(int postId, DateTime expirationDate, string userName)
        {
            PostId = postId;
            ExpirationDate = expirationDate;
            UserName = userName;
        }

    }
}
