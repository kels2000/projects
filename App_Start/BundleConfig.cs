#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc.
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

namespace USFS.WebUI.Me2U
{
    using System.Web.Optimization;

    /// <summary>
    /// Handles project bundling
    /// </summary>
    public class BundleConfig
    {

        /// <summary>
        /// Registers all of the required bundles
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Unobtrusive").Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/moment.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/slick.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/Styles").Include(
          "~/Styles/bootstrap.css",
           "~/Styles/utility.min.css",
           "~/Styles/Site.min.css",
           "~/Styles/bootstrap-datetimepicker.css"));
        }
    }
}