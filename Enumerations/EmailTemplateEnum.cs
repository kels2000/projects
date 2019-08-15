#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="EmailTemplateEnum.cs" company="United Shore Financial Services LLC.">
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
    /// Contains all of the definitions for email templates.
    /// </summary>
    public class EmailTemplateEnum : Enumeration
    {
        /// <summary>
        /// Email template for when a user has an item claimed.
        /// </summary>
        public static readonly EmailTemplateEnum ClaimEmailNotification = new EmailTemplateEnum(1, "ClaimEmailNotification");
        
        /// <summary>
        /// Email template for when a user claims a post.
        /// </summary>
        public static readonly EmailTemplateEnum EmailNotificationPostClaimed = new EmailTemplateEnum(2, "EmailNotificationPostClaimed");

        /// <summary>
        /// Email template for a non-winner of event tickets.
        /// </summary>
        public static readonly EmailTemplateEnum EventTicketNonWinner = new EmailTemplateEnum(3, "EventTicketNonWinner");

        /// <summary>
        /// Email template for a ticket winner.
        /// </summary>
        public static readonly EmailTemplateEnum EventTicketWinner = new EmailTemplateEnum(4, "EventTicketWinner");

        /// <summary>
        /// Email template for the individual who posted an 'item request' has the request claimed
        /// </summary>
        public static readonly EmailTemplateEnum ItemRequestClaimPoster = new EmailTemplateEnum(5, "ItemRequestClaimPoster");

        /// <summary>
        /// Email template for the individual who claimed an 'item request'
        /// </summary>
        public static readonly EmailTemplateEnum ItemRequestClaimClaimer = new EmailTemplateEnum(6, "ItemRequestClaimClaimer");

        /// <summary>
        /// Constructor for email template enumeration.
        /// </summary>
        /// <param name="id">the id of the enumeration record</param>
        /// <param name="name">the name of the enumeration record</param>
        private EmailTemplateEnum(int id, string name) : base(id.ToString(), name)
        {

        }
    }
}
