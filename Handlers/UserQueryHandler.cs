#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="UserQueryHandler.cs" company="United Shore Financial Services LLC.">
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
using USFS.Domain.Me2U.Contracts.Queries;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    /// <summary>
    /// Handler class for all user queries
    /// </summary>
    public class UserQueryHandler : IQueryHandler<SelectUserQuery, CurrentUser>,
                                    IQueryHandler<GetAllAdminsQuery, List<Admin>>,
                                    IQueryHandler<CheckAdminRightsQuery, bool>
    {
        /// <summary>
        /// The backing repository
        /// </summary>
        private readonly IUserRepository UserRepository;

        /// <summary>
        /// User query handler class constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserQueryHandler(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        /// <summary>
        /// Handler method for select user query --> selects 'CurrentUser' info from org chart based on the login name
        /// </summary>
        /// <param name="query">Select user query class</param>
        /// <returns>A current user object</returns>
        public CurrentUser Handle(SelectUserQuery query)
        {
            CurrentUser user = UserRepository.SelectUser(query.currentUser);
            return user;
        }

        /// <summary>
        /// Hander method for get all admins query --> gets the entire list of active admins from db
        /// </summary>
        /// <param name="query">Get all admins query class</param>
        /// <returns>A list if admins</returns>
        public List<Admin> Handle(GetAllAdminsQuery query)
        {
            return UserRepository.GetAllAdmins();
        }

        /// <summary>
        /// Checks the database to see if the current user is an active admin
        /// </summary>
        /// <param name="query">Check admin rights query class</param>
        /// <returns>bool that indicates if the current user is an admin or not</returns>
        public bool Handle(CheckAdminRightsQuery query)
        {
            return UserRepository.CheckAdminRights(query.LoginName);
        }
    }
}
