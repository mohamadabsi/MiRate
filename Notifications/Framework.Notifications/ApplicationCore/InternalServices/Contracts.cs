// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contracts.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Framework.Notifications.Entities;
using Framework.Notifications.ViewModels;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Framework.Notifications.Services
{ 
    /// <summary>
    ///     The EmailService interface.
    /// </summary>
    public interface IEmailService
    {

        Task<(NotificationEmailDetailss status, string errorMessage)> SendEmailAsync(MailMessage emailMessage, Guid id);
    }

    /// <summary>
    ///     The MobileNotificationService interface.
    /// </summary>
    public interface IMobileNotificationService
    {
        /// <summary>
        /// The send mobile notification.
        /// </summary>
        /// <param name="mobileNotification">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification Settings.
        /// </param>
        void SendMobileNotification(MobileNotification mobileNotification);
    }

    /// <summary>
    ///     The SmsService interface.
    /// </summary>
    public interface ISmsService
    {
        /// <summary>
        /// The send sms.
        /// </summary>
        /// <param name="smsMessage">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification Settings.
        /// </param>
        Task<SendSMSResponse> SendSms(SmsMessage smsMessage);
    }

    /// <summary>
    ///     The WebNotificationService interface.
    /// </summary>
    public interface IWebNotificationService
    {
        /// <summary>
        /// The send web notification.
        /// </summary>
        /// <param name="webNotification">
        /// The mobile notification message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SendWebNotification(WebNotification webNotification);
    }
}