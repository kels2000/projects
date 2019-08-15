using System;
using System.Collections.Generic;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    public interface IUserRepository
    {    
        CurrentUser SelectUser(CurrentUser currentUser);

        List<Admin> GetAllAdmins();

        bool CheckAdminRights(string loginName);
    }
}
