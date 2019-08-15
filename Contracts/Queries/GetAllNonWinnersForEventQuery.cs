#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="GetAllNonWinnersForEventQuery.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// A class that holds all of the information for the Get all non-winners for event query. 
    /// </summary>
    public class GetAllNonWinnersForEventQuery : IQuery<List<string>>
    {

        /// <summary>
        /// The id of the event we are getting non-winners for.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// The constructor for Get all non-winners for event query
        /// </summary>
        /// <param name="eventId">the id of the event we are gettin non-winners for.</param>
        public GetAllNonWinnersForEventQuery (int eventId)
        {
            EventId = eventId;
        }
    }
}
