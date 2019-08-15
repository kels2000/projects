#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="TicketClaimsRepository.cs" company="United Shore Financial Services LLC.">
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
using System.Linq;
using USFS.Core.Data;
using USFS.Domain.Me2U.Constants;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// Contains methods for accessing the database for the ticket claims page.
    /// </summary>
    public class TicketClaimsRepository : ITicketClaimsRepository
    {
        /// <summary>
        /// the data repository
        /// </summary>
        private DataRepository dataRepository { get; set; }

        /// <summary>
        /// constructor for ticketclaimsrepository
        /// </summary>
        /// <param name="dataRepository">the repository</param>
        public TicketClaimsRepository(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        /// <summary>
        /// Inserts a new ticket claim object in to the database 
        /// </summary>
        /// <param name="ticketClaim">information about a ticket claim</param>
        public void InsertTicketClaim(TicketClaims ticketClaim)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertTicketClaim);
            statement.AddParameter("EventId", ticketClaim.EventId);
            statement.AddParameter("EventName", ticketClaim.EventName);
            statement.AddParameter("FirstName", ticketClaim.FirstName);
            statement.AddParameter("LastName", ticketClaim.LastName);
            statement.AddParameter("EmailAddress", ticketClaim.EmailAddress);
            statement.AddParameter("UserName", ticketClaim.UserName);
            dataRepository.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Inserts an individual who was chosen to win tickets for an event.
        /// </summary>
        /// <param name="ticketWinner">Information about the individual who won tickets.</param>
        public void InsertTicketWinner(TicketWinner ticketWinner)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertTicketWinner);
            statement.AddParameter("EventId", ticketWinner.EventId);
            statement.AddParameter("WinnerEmailAddress", ticketWinner.EmployeeEmailAddress);
            statement.AddParameter("WinnerChosenBy", ticketWinner.AdminUserName);
            statement.AddParameter("WinnerUserName", ticketWinner.UserName);
            dataRepository.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Updates the number of remaining wins for an event.
        /// </summary>
        /// <param name="eventId">the id of the event</param>
        /// <param name="remainingWins">the number of remaining winners for the event.</param>
        public void UpdateRemainingWinnersForEvent (int eventId, int remainingWins)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpdateWinsRemaining);
            statement.AddParameter("eventId", eventId);
            statement.AddParameter("remainingWins", remainingWins);
            dataRepository.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Get all ticket claims from the database based on the event id 
        /// </summary>
        /// <param name="eventId">The id of the event to get the ticket claims for.</param>
        /// <returns>A list of ticket claims</returns>
        public List<TicketClaims> GetTicketClaimsByEventId(int eventId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetTicketClaimsByEventId);
            statement.AddParameter("EventId", eventId);
            return dataRepository.ExecuteStoredProc(statement, TicketClaimsMapper).ToList();
        }

        /// <summary>
        /// Maps ticket claims object
        /// </summary>
        /// <param name="data">the record from the database</param>
        /// <param name="rownum">the row numberof the record</param>
        /// <returns>A ticket claims object</returns>
        private TicketClaims TicketClaimsMapper(SqlReaderWrapper data, int rownum)
        {
            TicketClaims claims = new TicketClaims
            (data.GetInt("TicketClaimsId"),
                data.GetInt("EventId"),
                data.GetString("EventName"),
                data.GetString("FirstName"),
                data.GetString("LastName"),
                data.GetString("EmailAddress"),
                data.GetString("UserName"),
                data.GetDate("ClaimDate"),
                data.GetInt("TicketWins"),
                data.GetInt("HandRaises"));
            return claims;
        }
    }
}