#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="GetAllItemRequestPostsQuery.cs" company="United Shore Financial Services LLC.">
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
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries 
{
    /// <summary>
    /// Query for getting all posts of the type 'requesting an item'
    /// </summary>
    public class GetAllItemRequestPostsQuery : IQuery<IEnumerable<PostPreview>>
    {
        /// <summary>
        /// Constructor for GetAllItemRequestPostsQuery
        /// </summary>
        public GetAllItemRequestPostsQuery()
        {

        }
    }
}
