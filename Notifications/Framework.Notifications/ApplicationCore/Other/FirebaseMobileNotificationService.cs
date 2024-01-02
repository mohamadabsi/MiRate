﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FirebaseMobileNotificationService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.Services
{
    using Framework.Notifications.ViewModels;
    #region usings

    using System.Linq;

    #endregion

    /// <summary>
    ///     The firebase mobile notification service.
    /// </summary>
    public class FirebaseMobileNotificationService : IMobileNotificationService
    {
        /// <summary>
        /// The send mobile notification.
        /// </summary>
        /// <param name="mobileNotification">
        /// The mobile notification.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification Settings.
        /// </param>
        /// <exception cref="NotificationException">
        /// </exception>
        public void SendMobileNotification(
            MobileNotification mobileNotification
             )
        {
            //var firebaseClient = new FirebaseClient(
            //    //notificationSettings.GoogleFCMServerKey,
            //    //notificationSettings.GoogleFCMSenderId
            //    );

            //var sendResult = firebaseClient.SendNotification(mobileNotification);

            //if (!sendResult.IsValid)
            //{
            //    throw new NotificationException(
            //        sendResult.Errors?.FirstOrDefault()?.Value ?? "Firebase Error Occurred While Sending");
            //}
        }
    }
}