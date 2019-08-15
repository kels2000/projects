#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="Email.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.DTO
{
    /// <summary>
    /// An Email Object
    /// </summary>
    public class Email
    {  
        /// <summary>
        /// the name of the profile that hadles sending the emails in the database.
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// the individuals to send the email to
        /// </summary>
        public string Recipients { get; set; }

        /// <summary>
        /// the individuals to CC on the email.
        /// </summary>
        public string CcRecipients { get; set; }

        /// <summary>
        /// the subject line of the eamil
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// the from address of the email.
        /// </summary>
        public string FromAddress { get; set; }

        /// <summary>
        /// the replyto address
        /// </summary>
        public string ReplyTo { get; set; }

        /// <summary>
        /// the body text of the email.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// no arg construtor for email
        /// </summary>
        public Email()
        {
                
        }

        /// <summary>
        /// Construtor for email (4 params)
        /// </summary>
        /// <param name="profileName">the name of the profile that handles emails on the databse</param>
        /// <param name="recipients">the individuals to send the email to</param>
        /// <param name="subject">the subject line of the email.</param>
        /// <param name="body">the body text of the email.</param>
        public Email(string profileName, string recipients, string subject, string body)
        {
            ProfileName = profileName;
            Recipients = recipients;
            Subject = subject;
            Body = body;    
        }

        /// <summary>
        /// Construtor for email (7 params)
        /// </summary>
        /// <param name="profileName">the name of the profile that handles emails on the database</param>
        /// <param name="recipients">the individuals to send the email to</param>
        /// <param name="ccRecipients">the individuals to be included in the CC</param>
        /// <param name="subject">the subject line of the email</param>
        /// <param name="fromAddress">the address the email is sent from</param>
        /// <param name="replyTo">individuals to add to the replyto</param>
        /// <param name="body">the body text of the email.</param>
        public Email(string profileName, string recipients, string ccRecipients, string subject, string fromAddress, string replyTo, string body)
        {
            ProfileName = profileName;
            Recipients = recipients;
            CcRecipients = ccRecipients;
            Subject = subject;
            FromAddress = fromAddress;
            ReplyTo = replyTo;
            Body = body;    
        }
    }
}
