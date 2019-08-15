using System;
using System.Globalization;
using System.Web;

namespace USFS.Domain.Me2U.Helpers
{
    /// <summary>
    /// The custom Http Context object
    /// </summary>
    public class CustomSaltGenerator
    {
        /// <summary>
        /// The context base object
        /// </summary>
        private HttpContextBase context;

        /// <summary>
        /// The prefix of the salt.  This can be changed if desired
        /// </summary>
        private static readonly Guid saltPrefix = new Guid("2EA4DCDA-0192-4103-B1BE-1FD9239BCAE4");

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="contextObject">The base context object</param>
        public CustomSaltGenerator(HttpContextBase contextObject)
        {
            context = contextObject;
        }

        /// <summary>
        /// Gets the custom seed string for additional values appended to the default seed value
        /// </summary>
        /// <returns>string representing the custom secret string.</returns>
        public string GenerateCustomSaltString()
        {
            DateTimeFormatInfo currentDateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
            var currentYear = DateTime.Today.Year;
            var currentWeek = currentDateTimeFormatInfo.Calendar.GetWeekOfYear(DateTime.Today, currentDateTimeFormatInfo.CalendarWeekRule, currentDateTimeFormatInfo.FirstDayOfWeek);

            return string.Format("{0}{1}{2}", saltPrefix, currentYear, currentWeek);
        }
    }
}
