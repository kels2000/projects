using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Commands
{

    /// <summary>
    /// InsertPostCommand Command
    /// </summary>
    public class InsertPostCommand : DefaultCommand
    {

        /// <summary>
        /// Post Property and its getter and setter.
        /// </summary>
        public Post Post { get; set; }


        /// <summary>
        /// InsertPostCommand constructor.
        /// </summary>
        /// <param name="post"></param>
        public InsertPostCommand(Post post)
        {
            Post = post;
        }

    }
}
