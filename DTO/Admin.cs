#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.DTO
{
    public class Admin
    {
        /// <summary>
        /// Admin id from the db
        /// </summary>
        public int AdminId { get; private set; }

        /// <summary>
        /// Name of the admin in the admin table
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Admin's login id
        /// </summary>
        public string LoginId { get; private set; }

        /// <summary>
        /// Indicates whether the team member is currently an active admin
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Indicates whether this team member is a super admin
        /// </summary>
        public bool IsSuperAdmin { get; private set; }

        /// <summary>
        /// The date that the admin was given admin rights
        /// </summary>
        public DateTime DateAdded { get; private set; }

        /// <summary>
        /// The person who added this admin to the admin table
        /// </summary>
        public string AddedBy { get; private set; }


       /// <summary>
       /// Empty admin constructor
       /// </summary>
        public Admin()
        {
            
        }


      /// <summary>
      /// Admin object constructor
      /// </summary>
      /// <param name="adminId">The admin id</param>
      /// <param name="name">Name of the admin</param>
      /// <param name="loginId">Admin's login id</param>
      /// <param name="isActive">Indicates if the admin is a current admin</param>
      /// <param name="isSuperAdmin">Indicates if the admin is a super admin</param>
      /// <param name="dateAdded">The date the admin was given admin rights</param>
      /// <param name="addedBy">The person who gave this person admin rights</param>
        
        public Admin(int adminId, string name, string loginId, bool isActive, bool isSuperAdmin, DateTime dateAdded, string addedBy)
        {
            AdminId = adminId;
            Name = name;
            LoginId = loginId;
            IsActive = isActive;
            IsSuperAdmin = isSuperAdmin;
            DateAdded = dateAdded;
            AddedBy = addedBy;
        }



    }
}
