#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="IdentityModels.cs" company="United Shore Financial Services LLC.">
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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace USFS.WebUI.Me2U.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        /// <summary>
        /// The enum to set the Security Level
        /// </summary>
        public enum SecurtyLevelEnum
        {
            /// <summary>
            /// The none Level
            /// </summary>
            None,

            /// <summary>
            /// The project Level
            /// </summary>
            Project,

            /// <summary>
            /// The administrator Level
            /// </summary>
            Administrator,

            /// <summary>
            /// The roles Level
            /// </summary>
            Roles
        }

        /// <summary>
        /// The User Information Object
        /// </summary>
        [Serializable]
        public class UserInfo
        {
            /// <summary>
            /// Gets the full name of the user.
            /// </summary>
            /// <value>
            /// The full name of the user.
            /// </value>
            public string UserFullName { get; private set; }

            /// <summary>
            /// Gets the user identifier.
            /// </summary>
            /// <value>
            /// The user identifier.
            /// </value>
            public string UserId { get; private set; }

            /// <summary>
            /// Gets the user database identifier.
            /// </summary>
            /// <value>
            /// The user database identifier.
            /// </value>
            public int UserDbId { get; private set; }


            /// <summary>
            /// Gets the security level.
            /// </summary>
            /// <value>
            /// The security level.
            /// </value>

            public SecurtyLevelEnum[] SecurityLevel { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="UserInfo"/> class.
            /// </summary>
            /// <param name="userFullName">Full name of the user.</param>
            /// <param name="userId">The user identifier.</param>
            /// <param name="userDbId">The user database identifier.</param>
            /// <param name="securityLevel">The security level.</param>
            public UserInfo(string userFullName, string userId, int userDbId, List<SecurtyLevelEnum> securityLevel)
            {
                this.UserId = userId;
                this.UserFullName = userFullName;
                this.SecurityLevel = securityLevel.ToArray();
                this.UserDbId = userDbId;
            }

            /// <summary>
            /// Deserializes the specified object array.
            /// </summary>
            /// <param name="objectArray">The object array.</param>
            /// <returns></returns>
            public static UserInfo Deserialize(byte[] objectArray)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(objectArray);
                stream.Seek(0, SeekOrigin.Begin);
                return (UserInfo)formatter.Deserialize(stream);
            }

            /// <summary>
            /// Serializes this instance.
            /// </summary>
            /// <returns></returns>
            public Byte[] Serialize()
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                StreamReader streamReader = new StreamReader(stream);
                formatter.Serialize(stream, this);
                return stream.ToArray();
            }
        }
    }
}