#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="ImageHelper.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Helpers
{
    using System.Configuration;

    /// <summary>
    /// Helper class for returning image paths, descriptions, information, etc
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Gets the image path
        /// </summary>
        /// <param name="uniqueFileName"></param>
        /// <returns></returns>
        public static string GetPathFromConfig(string uniqueFileName)
        {
            string path = ConfigurationManager.AppSettings["Me2UImagePath"];
            string environment = ConfigurationManager.AppSettings["Environment"];

            return string.Format(@"{0}{1}\\{2}", path, environment, uniqueFileName);
        }
    }
}