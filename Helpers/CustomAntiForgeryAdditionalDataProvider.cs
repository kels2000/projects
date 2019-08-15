using System;
using System.Web;

namespace USFS.Domain.Me2U.Helpers
{
    /// <summary>
    /// Custom Anti-Forgery Additional Data provider
    /// </summary>
    public class CustomAntiForgeryAdditionalDataProvider //:IAntiForgeryAdditionalDataProvider
    {
        /// <summary>
        /// Returns the additional data to be appended to the default salt.
        /// </summary>
        /// <param name="context">The context base object.</param>
        /// <returns></returns>
        public string GetAdditionalData(HttpContextBase context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var customContext = new CustomSaltGenerator(context);
            return customContext.GenerateCustomSaltString();
        }

        /// <summary>
        /// Validates the additional data with the data sent by client
        /// </summary>
        /// <param name="context">The context base object.</param>
        /// <param name="additionalData">The secret string to be compared with.</param>
        /// <returns></returns>
        public bool ValidateAdditionalData(HttpContextBase context, string additionalData)
        {
            string data = GetAdditionalData(context);
            return string.Compare(data, additionalData, StringComparison.Ordinal) == 0;
        }
    }
}
