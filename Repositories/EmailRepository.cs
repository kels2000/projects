#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EmailRepository.cs" company="United Shore Financial Services LLC.">
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

using System.Linq;
using USFS.Core.Data;
using USFS.Domain.Me2U.Constants;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// Repository for handling emails.
    /// </summary>
    public class EmailRepository : IEmailRepository
    {
        /// <summary>
        /// The database.
        /// </summary>
        private DataRepository db { get; set; }

        /// <summary>
        /// constructor for the email repository
        /// </summary>
        /// <param name="database">the database</param>
        public EmailRepository(DataRepository database)
        {
            db = database;
        }

        /// <summary>
        /// Retrieves an email template from the database.
        /// </summary>
        /// <param name="emailTemplate">name of the template to retrieve</param>
        /// <returns>the information for an email template (body, subject)</returns>
        public EmailTemplate GetEmailTemplate(EmailTemplate emailTemplate)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetEmailTemplate);
            statement.AddParameter("templateName", emailTemplate.EmailTemplateName);
            return db.ExecuteStoredProc(statement, EmailMapper).FirstOrDefault();
        }

        /// <summary>
        /// Maps the data from the databas to an object
        /// </summary>
        /// <param name="data">the data from one record in the databse.</param>
        /// <param name="rownum">the row number of the record.</param>
        /// <returns>the information about an email template mapped to an object.</returns>
        private EmailTemplate EmailMapper(SqlReaderWrapper data, int rownum)
        {
            return new EmailTemplate(data.GetString("TemplateName"), data.GetString("EmailBody"), data.GetString("EmailSubject"));
        }

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="email">all of the information about sending the email.</param>
        public void SendEmail(Email email)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.SendEmail);
            statement.AddParameter("Profile_name", email.ProfileName);
            statement.AddParameter("Recipients", email.Recipients);
            statement.AddParameter("Copy_recipients", email.CcRecipients);
            statement.AddParameter("Subject", email.Subject);
            statement.AddParameter("Body", email.Body);
            db.ExecuteStoredProc(statement);
        }
    }
}
