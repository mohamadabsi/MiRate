// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Framework.Notifications.ViewModels
{
    /// <summary>
    ///     The notification types.
    /// </summary>
    public enum NotificationTypes
    {
        /// <summary>
        ///     The email.
        /// </summary>
        Email = 100,

        /// <summary>
        ///     The sms.
        /// </summary>
        Sms = 200,  

        /// <summary>
        ///     The mobile notification
        /// </summary>
        [Description("Mobile Notification")]
        MobileNotification = 300,

        /// <summary>
        ///     The web notification.
        /// </summary>
        [Description("Web Notification")]
        WebNotification = 400
    }

    /// <summary>
    /// The notification language.
    /// </summary>
    public enum NotificationLanguage
    {
        /// <summary>
        /// The ar.
        /// </summary>
        Ar = 1,

        /// <summary>
        /// The en.
        /// </summary>
        En = 2
    }
}