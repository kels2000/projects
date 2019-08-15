#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="OrgChartUser.cs" company="United Shore Financial Services LLC.">
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


namespace USFS.Domain.Me2U.DTO
{
    public class OrgChartUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public OrgChartUser()
        {
                
        }

        public OrgChartUser(string firstName, string lastName, string fullName, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            FullName = fullName;    
        }
    }
}
