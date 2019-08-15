#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="United Shore Financial Services LLC.">
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
    using System;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using Newtonsoft.Json.Converters;
    public class WebApiConfig
    {
        /// <summary>
        /// register for the web API
        /// </summary>
        /// <param name="config">hte HTTP configuration</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Clear();
            config.Formatters.Add(new HeartBeatJsonFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
        }

        /// <summary>
        /// formatter for json heart beat objects
        /// </summary>
        public class HeartBeatJsonFormatter
            : JsonMediaTypeFormatter
        {
            /// <summary>
            /// the heart beat formatter
            /// </summary>
            public HeartBeatJsonFormatter()
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            }

            /// <summary>
            /// sets the default content headers
            /// </summary>
            /// <param name="type"> the type of content</param>
            /// <param name="headers">the HTTP headers</param>
            /// <param name="mediaType">the type of media</param>
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
                headers.ContentType.CharSet = "utf-8";
            }
        }
    }
}