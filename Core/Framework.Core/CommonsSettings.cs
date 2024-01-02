// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonsSettings.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core
{
    #region usings

    using Microsoft.Extensions.Configuration;
    using System;

    #endregion

    /// <summary>
    ///     The commons settings.
    /// </summary>
    public static class CommonsSettings
    {
        /// <summary>
        /// The application root url.
        /// </summary>
        public static string ApplicationRootUrl =>
            ConfigurationHelper.Configuration.GetValue<string>("Commons:ApplicationRootUrl") ?? string.Empty;

        public static string ApplicationId =>
            ConfigurationHelper.Configuration.GetValue<string>("Commons:ApplicationId") ?? string.Empty;

        // 0 public static string ApplicationName { get; internal set; } = "MyApplicationName";

        /// <summary>
        ///     Gets the connection string name.
        /// </summary>
        public static string ConnectionStringName =>
            ConfigurationHelper.Configuration.GetValue<string>("ApplicationConnection");

        /// <summary>
        ///     Gets the connection string value.
        /// </summary>
        public static string ConnectionStringValue =>
            ConfigurationHelper.Configuration.GetConnectionString(ConnectionStringName);

        /// <summary>
        ///     Gets the default culture.
        /// </summary>
        public static string DefaultCulture { get; internal set; } = "ar-SA";

        /// <summary>
        ///     Gets or sets the widgets static content version.
        /// </summary>
        public static uint WidgetsStaticContentVersion { get; set; } = 1;

        /// <summary>
        ///     Gets or sets the PageSize
        /// </summary>
        public static int PageSize { get; set; } =10;

        public static DateTime MeetingsStartDate  => DateTime.Now.Date;

        public static DateTime CurrentDate => DateTime.Now.Date;
        public static GoogleCaptchaSettings GoogleCaptcha=>
            ConfigurationHelper.Configuration.GetValue<GoogleCaptchaSettings>("Captcha");

        public static string BaseUrl =>
         ConfigurationHelper.Configuration.GetValue<string>("BaseUrl");
    }


    public class GoogleCaptchaSettings
    {
        public string SecretKey { get; set; }
        public string SiteKey { get; set; }
        public bool Enable { get; set; }
        public string[] EnableForPages { get; set; }
        public string SecretKey_Android { get; set; }
        public string SecretKey_IOS { get; set; }

    }
}