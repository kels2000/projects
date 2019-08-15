#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="PostTypeEnum.cs" company="United Shore Financial Services LLC.">
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
    /// Enumeration to store different post types.
    /// </summary>
    public class PostPurposeEnum : Enumeration
    {
        /// <summary>
        /// Enum post type for looking for an item.
        /// </summary>
        public static readonly PostPurposeEnum ItemRequest = new PostPurposeEnum(1, "Request an Item");

        /// <summary>
        /// Enum post type for giving an item away.
        /// </summary>
        public static readonly PostPurposeEnum ItemPost = new PostPurposeEnum(2, "Post an Item");

        /// <summary>
        /// Post Type enumeration constructor.
        /// </summary>
        /// <param name="id">the id of the enum entry</param>
        /// <param name="name">the display text of the enum type</param>
        private PostPurposeEnum(int id, string name) : base(id.ToString(), name)
        {

        }

    }
}
