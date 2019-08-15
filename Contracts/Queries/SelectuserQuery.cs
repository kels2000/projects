using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    public class SelectUserQuery : IQuery<CurrentUser>
    {
        public CurrentUser currentUser;

        public SelectUserQuery(CurrentUser CurrentUser)
        {
            currentUser = CurrentUser;
        }
    }
}
