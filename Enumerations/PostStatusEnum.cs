#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="PostStatusEnum.cs" company="United Shore Financial Services LLC.">
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
using USFS.Core;

namespace USFS.Domain.Me2U.Enumerations
{
    /// <summary>
    /// Enumeration to hold information about the different types of post statuses
    /// </summary>
    public class PostStatusEnum : Enumeration
    {
        /// <summary>
        /// Constructor for PostStatusEnum class
        /// </summary>
        /// <param name="id">the id of the enumeration record</param>
        /// <param name="name">the name of the enumeration record</param>
        public PostStatusEnum(string id, string name) : base(id, name)
        {
            
        }
        /// <summary>
        /// Active PostEnum
        /// </summary>
        public static readonly PostStatusEnum Active = new PostStatusEnum("1","Active");

        /// <summary>
        /// PendingDelivery PostEnum
        /// </summary>
        public static readonly PostStatusEnum PendingDelivery = new PostStatusEnum("2", "PendingDelivery");

        /// <summary>
        /// Inactive PostEnum
        /// </summary>
        public static readonly PostStatusEnum Delivered = new PostStatusEnum("3", "Delivered");

        /// <summary>
        /// Inactive PostEnum
        /// </summary>
        public static readonly PostStatusEnum InActive = new PostStatusEnum("4", "Inactive");

        /// <summary>
        /// Status for when a post has been deleted
        /// </summary>
        public static readonly PostStatusEnum Deleted = new PostStatusEnum("5", "Deleted");
    }
}
