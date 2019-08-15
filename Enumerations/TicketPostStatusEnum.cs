using USFS.Core;

namespace USFS.Domain.Me2U.Enumerations
{
    public class TicketPostStatusEnum : Enumeration
    {

        /// <summary>
        /// TicketPostStatusEnum Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TicketPostStatusEnum(string id, string name) : base(id, name)
        {
            
        }


        /// <summary>
        /// Ticket Post Marked As Active
        /// </summary>
        public static readonly TicketPostStatusEnum Active = new TicketPostStatusEnum("1", "Active");

        /// <summary>
        /// Ticket Post Mated as Inactive
        /// </summary>
        public static readonly TicketPostStatusEnum Inactive = new TicketPostStatusEnum("2", "Inactive");


    }


}