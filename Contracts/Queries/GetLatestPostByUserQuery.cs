using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    public class GetLatestPostByUserQuery : IQuery<Post>
    {
        public string username;

        public GetLatestPostByUserQuery(string UserName)
        {
            username = UserName;
        }

    }
}
