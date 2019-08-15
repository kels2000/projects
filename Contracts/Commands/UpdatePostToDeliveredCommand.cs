#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="UpdatePostToDeliveredCommand.cs" company="United Shore Financial Services LLC.">
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
    public class UpdatePostToDeliveredCommand : DefaultCommand
    {
        /// <summary>
        /// The post to be marked as deliverd
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// The user name of the individual who is marking the post as delivered
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Constructor for UpdatePostToDeliverd Command
        /// </summary>
        /// <param name="post">the post to be marked as deliverd</param>
        /// <param name="userName">the user name of the individual who is marking the post as delivered</param>
        public UpdatePostToDeliveredCommand(Post post, string userName)
        {
            Post = post;
            UserName = userName;
        }
    }
}
