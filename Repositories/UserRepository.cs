using System;
using System.Collections.Generic;
using System.Linq;
using USFS.Core.Data;
using USFS.Core.Exceptions;
using USFS.Domain.Me2U.Constants;
using USFS.Domain.Me2U.DTO;
using USFS.Lending.Enum;
using USFS.Lending.Fees;
using USFS.Lending.Security;

namespace USFS.Domain.Me2U.Repositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>the data repository</summary>
        private DataRepository db { get; set; }

        /// <summary>constructs the meeting repository</summary>
        /// <param name="database">the data repository to use</param>
        public UserRepository(DataRepository database)
        {
            db = database;
        }

        public CurrentUser SelectUser(CurrentUser currentUser)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.SelectUser);
            statement.AddParameter("loginName", currentUser.LoginName);
            return db.ExecuteStoredProc(statement, MapSecurityUser).FirstOrDefault();
        }


        /// <summary>
        /// Execture stroed proc to get list of admins from admin table
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAllAdmins()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllAdmins);
            return db.ExecuteStoredProc(statement, MapAdmin).ToList();
        }

        /// <summary>
        /// Executes stored proc to get true or false value is the current user is an admin or not
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns>bool that indicates if the user is an admin or not</returns>
        public bool CheckAdminRights(string loginName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.CheckAdminRights);
            statement.AddParameter("LoginName", loginName);
            return db.ExecuteStoredProc(statement, delegate (SqlReaderWrapper data, int rows)
            {
                return data.GetBoolean("IsAdmin");
            }).FirstOrDefault();
       
        }


        /// <summary>
        /// Current user object  mapper
        /// </summary>
        /// <param name="data"></param>
        /// <param name="row"></param>
        /// <returns>Current User object</returns>
        private CurrentUser MapSecurityUser(SqlReaderWrapper data, int row)
        {
            return new CurrentUser(data.GetString("loginname"), 
                                   data.GetString("emailaddress"),
                                   data.GetString("firstname"),
                                   data.GetString("lastname"), 
                                   data.GetString("fullname"));
        }


        /// <summary>
        /// Admin object mapper
        /// </summary>
        /// <param name="data"></param>
        /// <param name="row"></param>
        /// <returns>Admin object</returns>
        private Admin MapAdmin(SqlReaderWrapper data, int row)
        {
            return new Admin(data.GetInt("AdminId"),
                             data.GetString("Name"),
                             data.GetString("LoginId"),
                             data.GetBoolean("IsActive"),
                             data.GetBoolean("IsSuperAdmin"),
                             data.GetDate("DateAdded"),
                             data.GetString("AddedBy"));
        }


    }
}
