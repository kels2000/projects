#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="RemovePostCommand.cs" company="United Shore Financial Services LLC.">
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
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{
    /// <summary>
    /// Class that contains the command to remove a post.
    /// </summary>
    public class RemovePostCommand : DefaultCommand
    {
        /// <summary>
        /// the post to be changed to deleted status
        /// </summary>
        public Post Post { get; private set; }

        /// <summary>
        /// the username of the individual who is setting this post to deleted
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Constructor for RemovePostCommand
        /// </summary>
        /// <param name="post">the post to be switched to the 'deleted' status</param>
        /// <param name="userName">the username of the individual who is changing the status</param>
        public RemovePostCommand(Post post, string userName)
        {
            Post = post;
            UserName = userName;
        }
    }
}
