//#region Copyright

////------------------------------------------------------------------------------------------
//// <copyright file="User.cs" company="United Shore Financial Services LLC.">
////     Copyright &copy; United Shore Financial Services Inc. 2017.
//// 
////     Copyright in the application source code, and in the information and
////     material therein and in their arrangement, is owned by United Shore Financial Services LLC.
////     unless otherwise indicated.
//// 
////     You shall not remove or obscure any copyright, trademark or other notices.
////     You may not copy, republish, redistribute, transmit, participate in the
////     transmission of, create derivatives of, alter edit or exploit in any
////     manner any material including by storage on retrieval systems, without the
////     express written permission of United Shore Financial Services LLC.
//// </copyright>
////------------------------------------------------------------------------------------------

//#endregion

//using System;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Runtime.Serialization.Json;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Text;
//using System.Threading;
//using System.Web.Security;
//using USFS.Lending;
//using USFS.Lending.ProcessAppraisalXML.AppraisalXsdGeneratedVersion2Dot6;
//using USFS.Lending.Security;

//namespace USFS.Domain.Me2U.Security
//{
//    public class User : WindowsPrincipal
//    {
//        // SHOREMORTGAGE\\
//        private const string AdminGroupName = "GRP-S-Me2You Admins";//"SHOREMORTGAGE\\GRP-S-Me2You Admins";

//       /* private const string SuperAdminGroupName = "GRP-S-Me2You SuperAdmins";*///"SHOREMORTGAGE\\GRP-S-Me2You SuperAdmins";

//        public bool HasAdminRole { get; }
//        //public bool HasSuperAdminRole { get; }

//        public User(WindowsIdentity identity) : base(identity)
//        {
//            HasAdminRole = base.IsInRole(AdminGroupName);
//        //    HasSuperAdminRole = base.IsInRole(SuperAdminGroupName);
//        }
        
//        /// <summary>
//        /// Returns the object's data as a JSON representation.
//        /// </summary>
//        /// <returns>JSON</returns>
//        public string ToJson()
//        {
//            string returnValue;
//            var representation = new PrincipalRepresentation
//            {
//                Name = base.Identity.Name,
//                IsAuthenticated = base.Identity.IsAuthenticated,
//                Type = base.Identity.AuthenticationType,
//                IsInAdminGroup = HasAdminRole,
//                //IsInSuperAdminGroup = HasSuperAdminRole
//            };

//            var jsonSerializer = new DataContractJsonSerializer(typeof(PrincipalRepresentation));
//            using (var stream = new MemoryStream())
//            {
//                jsonSerializer.WriteObject(stream, representation);
//                stream.Flush();
//                var json = stream.ToArray();
//                returnValue = Encoding.UTF8.GetString(json, 0, json.Length);
//            }

//            return returnValue;
//        }

//        /// <summary>
//        /// Builds the Lending identity from the authorization ticket (from cookie).
//        /// </summary>
//        /// <param name="authTicket">the authorization ticket.</param>
//        /// <returns>the lending identity.</returns>
//        public static User FromJson(FormsAuthenticationTicket authTicket)
//        {
//            if (string.IsNullOrEmpty(authTicket?.Name))
//            {
//                return null;
//            }

//            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(authTicket.UserData)))
//            {

//                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(PrincipalRepresentation));
//                var principalRepresentation = jsonSerializer.ReadObject(stream) as PrincipalRepresentation;
//                stream.Close();
//            }

//            return new User(WindowsIdentity.GetCurrent());
//        } 
//    }
//}



