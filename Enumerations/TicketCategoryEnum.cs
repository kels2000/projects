using USFS.Core;

namespace USFS.Domain.Me2U.Enumerations
{
    public class TicketCategoryEnum : Enumeration
    {

        /// <summary>
        /// Category enumeration constructor.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        private TicketCategoryEnum(int id, string name) : base(id.ToString(), name)
        {

        }
        
        ///Ticket Category Enumerations

        /// <summary>
        /// TicketSports object of type CategoryEnum
        /// </summary>
        public static readonly TicketCategoryEnum TicketSports = new TicketCategoryEnum(1, "Sports");

        /// <summary>
        /// TicketFamily of type CategoryEnum
        /// </summary>
        public static readonly TicketCategoryEnum TicketFamily = new TicketCategoryEnum(2, "Family");

        /// <summary>
        /// TicketConcerts object of type CategoryEnum
        /// </summary>
        public static readonly TicketCategoryEnum TicketConcerts = new TicketCategoryEnum(3, "Concerts");

    }
}

