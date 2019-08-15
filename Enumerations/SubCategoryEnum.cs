#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="SubCategoryEnum.cs" company="United Shore Financial Services LLC.">
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

using USFS.Core;

namespace USFS.Domain.Me2U.Enumerations
{
    /// <summary>
    ///SubCategory enumerations
    /// </summary>
    public class SubCategoryEnum : Enumeration
    {
        /// <summary>
        /// ParentId property
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// SubCategory enumeration constructor.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        /// <param name="parentId">string</param>
        private SubCategoryEnum(int id, string name, int parentId) : base(id.ToString(), name)
        {
            ParentId = parentId;
        }

        //Electronics and Computers SubCategories

        /// <summary>
        /// Tvs object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Tvs = new SubCategoryEnum(5, "TVs", 1);

        /// <summary>
        /// Desktops And Laptops object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum DesktopsAndLaptops = new SubCategoryEnum(6, "Desktops & Laptops", 1);

        /// <summary>
        /// Phones object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Phones = new SubCategoryEnum(7, "Phones", 1);

        /// <summary>
        /// CdsDvdsAndBlurays object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum CdsDvdsAndBlurays = new SubCategoryEnum(35, "Cd's, Dvd's, Blu-Rays", 1);

        /// <summary>
        /// Gaming object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Gaming = new SubCategoryEnum(36, "Gaming", 1);

        /// <summary>
        /// ElectronicMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum ElectronicMisc = new SubCategoryEnum(8, "Miscellaneous", 1);

        //Household SubCategories

        /// <summary>
        /// Appliances object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Appliances = new SubCategoryEnum(4, "Appliances", 2);

        /// <summary>
        /// Tools object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Tools = new SubCategoryEnum(24, "Tools", 2);

        /// <summary>
        /// Supplies object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Supplies = new SubCategoryEnum(30, "Supplies", 2);

        /// <summary>
        /// LawnAndGarden object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum LawnAndGarden = new SubCategoryEnum(31, "Lawn And Garden", 2);

        /// <summary>
        /// Automotive object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Automotive = new SubCategoryEnum(32, "Automotive", 2);

        /// <summary>
        /// HouseholdMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum HouseholdMisc = new SubCategoryEnum(33, "Miscellaneous", 2);


        //Toys & Kids SubCategories

        /// <summary>
        /// Clothing object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Clothing = new SubCategoryEnum(9, "Clothing", 3);

        /// <summary>
        /// Toys object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Toys = new SubCategoryEnum(10, "Toys", 3);

        /// <summary>
        /// ToysMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum ToysMisc = new SubCategoryEnum(11, "Miscellaneous", 3);

        //Health & Wellness SubCategories

        /// <summary>
        /// BathAndBody object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum BathAndBody = new SubCategoryEnum(12, "Bath & Body", 4);

        /// <summary>
        /// NewMakeup object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum NewMakeup = new SubCategoryEnum(13, "New Makeup", 4);

        /// <summary>
        /// Fitness object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Fitness = new SubCategoryEnum(14, "Fitness", 4);

        /// <summary>
        /// HealthMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum HealthMisc = new SubCategoryEnum(15, "Miscellaneous", 4);

        //Clothing & Shoes SubCategories

        /// <summary>
        /// Men object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Men = new SubCategoryEnum(16, "Men", 5);

        /// <summary>
        /// Women object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Women = new SubCategoryEnum(17, "Women", 5);

        /// <summary>
        /// Boys object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Boys = new SubCategoryEnum(18, "Boys", 5);

        /// <summary>
        /// Girls object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Girls = new SubCategoryEnum(19, "Girls", 5);

        //Sports SubCategories

        /// <summary>
        /// SuppliesAndGear object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum SuppliesAndGear = new SubCategoryEnum(20, "Supplies & Gear", 6);

        /// <summary>
        /// CampingAndFishing object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum CampingAndFishing = new SubCategoryEnum(22, "Camping & Fishing", 6);

        /// <summary>
        /// SportsMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum SportsMisc = new SubCategoryEnum(21, "Miscellaneous", 6);

        //Furniture SubCategories

        /// <summary>
        /// Outdoor object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Outdoor = new SubCategoryEnum(25, "Outdoor", 7);

        /// <summary>
        /// KitchenAndDining object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum KitchenAndDining = new SubCategoryEnum(1, "Kitchen & Dining", 7);

        /// <summary>
        /// Bathroom object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Bathroom = new SubCategoryEnum(2, "Bathroom", 7);

        /// <summary>
        /// Bedroom object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum Bedroom = new SubCategoryEnum(3, "Bedroom", 7);

        /// <summary>
        /// FurnitureMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum FurnitureMisc = new SubCategoryEnum(26, "Miscellaneous", 7);

        //Baby SubCategories

        /// <summary>
        /// BabyClothing object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum BabyClothing = new SubCategoryEnum(27, "Clothing", 8);

        /// <summary>
        /// BabyToys object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum BabyToys = new SubCategoryEnum(28, "Toys", 8);

        /// <summary>
        /// BabyMisc object of type SubCategoryEnum
        /// </summary>
        public static readonly SubCategoryEnum BabyMisc = new SubCategoryEnum(29, "Miscellaneous", 8);
    }
}
