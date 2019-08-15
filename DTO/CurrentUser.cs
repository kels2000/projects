#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="CurrentUser.cs" company="United Shore Financial Services LLC.">
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
    /// Class to represent the currently logged in user.
    /// </summary>
    public class CurrentUser
    { 
        /// <summary>
        /// The first name of the currently logged in user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the currently logged in user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the email address of the currently logged in user.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The loging name of the currently logged in user.
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// the full name of the currently logged in user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// No arg constructor for currentuser
        /// </summary>
        public CurrentUser()
        {
        }

        /// <summary>
        /// constructor for currentuser (1 parameter)
        /// </summary>
        /// <param name="loginName">the login name of the currently logged in user.</param>
        public CurrentUser(string loginName)
        {
            LoginName = loginName;
        }

        /// <summary>
        /// Constructor for currentuser
        /// </summary>
        /// <param name="loginName">the login name of the currently logged in individual.</param>
        /// <param name="emailAddress">the email address of the currently logged in individual.</param>
        /// <param name="firstName">the first name of the currently logged in individual</param>
        /// <param name="lastName">the last name of the currently logged in individual.</param>
        /// <param name="fullName">the full name of the currently logged in individual.</param>
        public CurrentUser(string loginName, string emailAddress, string firstName, string lastName, string fullName) :
            this(loginName)
        {
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
        }
    }
}
