using USFS.Core;

namespace USFS.Domain.Me2U.Enumerations
{
    public class PostType : Enumeration
    {
        private PostType(int id, string description) : base(id.ToString(), description)
        {

        }

        public static readonly PostType regularPost = new PostType(1, "Regular Post");

        public static readonly PostType ticketPost = new PostType(2, "Ticket Post");
    }
}
