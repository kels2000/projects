#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EmailTemplate.cs" company="United Shore Financial Services LLC.">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USFS.Domain.Me2U.DTO
{
    /// <summary>
    /// Class to store information about email templates.
    /// </summary>
    public class EmailTemplate
    {
        ///<summary>Id of Email</summary>
        public string EmailTemplateName { get; set; }

        ///<summary>Body of Email.</summary>
        public string EmailBody { get; set; }

        ///<summary>Subject line of Email.</summary>
        public string EmailSubject { get; set; }

        /// <summary>
        /// constructor for EmailTemplate object
        /// </summary>
        /// <param name="emailBody">Email body to be parsed</param>
        /// <param name="emailSubject">Email subject to be parsed</param>
        public EmailTemplate(string emailTemplateName)
        {
            EmailTemplateName = emailTemplateName;
        }

        /// <summary>
        /// 3 argument constructor for email template
        /// </summary>
        /// <param name="emailTemplateName">the name of the email template to use</param>
        /// <param name="emailBody">The body text of the email.</param>
        /// <param name="emailSubject">The subject line of the email.</param>
        public EmailTemplate(string emailTemplateName, string emailBody, string emailSubject)
            : this(emailTemplateName)
        {
            EmailBody = emailBody;
            EmailSubject = emailSubject;
        }


    }
}
