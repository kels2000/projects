using USFS.Core;

namespace USFS.Domain.Me2U.Enumerations
{
    public class CategoryEnum : Enumeration
    {

        /// <summary>
        /// Category enumeration constructor.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        private CategoryEnum(int id, string name) : base(id.ToString(), name)
        {

        }
        /// <summary>
        /// Electronics and Computers object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum ElectronicsAndComputers = new CategoryEnum(1, "Electronics & Computers");

        /// <summary>
        /// Household object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum HouseHold = new CategoryEnum(2, "Household");

        /// <summary>
        /// Toys and Kids object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum ToysAndKids = new CategoryEnum(3, "Toys & Kids");

        /// <summary>
        /// Automotive object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum HealthAndWellness = new CategoryEnum(4, "Health & Wellness");

        /// <summary>
        /// Clothing and Shoes object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum ClothingAndShoes = new CategoryEnum(5, "Clothing & Shoes");

        /// <summary>
        /// Sports object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum Sports = new CategoryEnum(6, "Sports");

        /// <summary>
        /// Furniture object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum Furniture = new CategoryEnum(7, "Furniture");

        /// <summary>
        /// Baby object of type CategoryEnum
        /// </summary>
        public static readonly CategoryEnum Baby = new CategoryEnum(8, "Baby");
       
    }
}
