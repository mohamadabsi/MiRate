// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpEmailService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications
{
    using Framework.Notifications.Entities;
    using Framework.Notifications.Services;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks; 

    /// <summary>
    ///     The smtp email service.
    /// </summary>
    public class SmtpEmailService : IEmailService
    {
        private readonly INotificationSettingsService notificationSettings;

        public SmtpEmailService(INotificationSettingsService notificationSettings)
        {
            this.notificationSettings = notificationSettings;
        }
        /// <summary>
        /// The send email.
        /// </summary>
        /// <param name="emailMessage">
        /// The email message.
        /// </param>
        /// <param name="notificationSettings">
        /// todo: describe notificationSettings parameter on SendEmail
        /// </param>
        public async Task<( NotificationEmailDetailss status, string errorMessage)> SendEmailAsync(MailMessage emailMessage, Guid id)
        {
            try
            {
                emailMessage.From = new MailAddress(notificationSettings.EmailFromAddress, notificationSettings.EmailFromName);


                #region FathyTest

                //using (var smtpClient = new SmtpClient
                //{

                //    Host = "smtp.office365.com",
                //    //UseDefaultCredentials = false,
                //    Port = notificationSettings.SmtpPort,
                //    EnableSsl = notificationSettings.SmtpEnableSSL,
                //    //DeliveryMethod = SmtpDeliveryMethod.Network,
                //    Credentials = new NetworkCredential(
                //                              "noreply@saudiexim.gov.sa",
                //                              "Mod63041")
                //})

                #endregion


                #region 

                using (var smtpClient = new SmtpClient
                {

                    Host = notificationSettings.SmtpServer,
                    //UseDefaultCredentials = false,
                    Port = notificationSettings.SmtpPort,
                    EnableSsl = notificationSettings.SmtpEnableSSL,
                    //DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(
                                                notificationSettings.SmtpUserName,
                                                notificationSettings.SmtpPassword)
                })
                #endregion
                {

                    //ServicePointManager.SecurityProtocol =
                    //    SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    emailMessage.IsBodyHtml = true; 
                    try
                    {
                          smtpClient.Send(emailMessage);
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {

                        for (int i = 0; i < ex.InnerExceptions.Length; i++)
                        {
                            SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                            if (status == SmtpStatusCode.MailboxBusy)
                            {
                                return await Task.FromResult(( NotificationEmailDetailss.MailboxBusy, $"Delivery failed - retrying in 5 seconds.{ex.Message}"));

                            }
                            else if (status == SmtpStatusCode.MailboxUnavailable)
                            {
                                return await Task.FromResult(( NotificationEmailDetailss.MailboxUnavailable, $"Delivery failed - retrying in 5 seconds. {ex.Message}"));

                            }
                            else
                            {
                                return await Task.FromResult(( NotificationEmailDetailss.FailedRecipient, $"Failed to deliver message to {ex.InnerExceptions[i].FailedRecipient}"));
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        return await Task.FromResult((NotificationEmailDetailss.RetryIfBusy, $"Retry Busy {ex.Message.ToString()}"));
                    }


                    return await Task.FromResult(( NotificationEmailDetailss.Successfully,"Message Sent"));
                }
            }
            catch (Exception e)
            {
                return await Task.FromResult((NotificationEmailDetailss.Failed,e.Message));
            }
        }

        //private void SendMessge(EmailMessage emailMessage)
        //{
        //    try
        //    {
        //        using (var smtpClient = new SmtpClient
        //        {
        //            Host = notificationSettings.SmtpServer,
        //            UseDefaultCredentials = false,
        //            Port = notificationSettings.SmtpPort,
        //            EnableSsl = notificationSettings.SmtpEnableSSL,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            Credentials = new NetworkCredential(
        //            notificationSettings.SmtpUserName,
        //            notificationSettings.SmtpPassword)
        //        })
        //        {
        //            emailMessage.From = notificationSettings.EmailFromAddress;
        //            emailMessage.DisplayName = notificationSettings.EmailFromName;
        //            var mail = emailMessage.ToMailMessage();
        //            mail.Sender = new MailAddress(emailMessage.From, emailMessage.DisplayName);
        //            //ServicePointManager.SecurityProtocol =
        //            //    SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        //         //   var notificationEmailDetails = SaveNotificationEmailDetails(emailMessage, mail);
        //            try
        //            {
        //                smtpClient.Send(mail);
        //            }
        //            catch (SmtpFailedRecipientsException ex)
        //            {

        //                for (int i = 0; i < ex.InnerExceptions.Length; i++)
        //                {
        //                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
        //                    if (status == SmtpStatusCode.MailboxBusy)
        //                    {
        //                        notificationEmailDetails.Update((int)NotificationEmailDetailss.MailboxBusy, "Delivery failed - retrying in 5 seconds.");

        //                    }
        //                    else if (status == SmtpStatusCode.MailboxUnavailable)
        //                    {
        //                        notificationEmailDetails.Update((int)NotificationEmailDetailss.MailboxUnavailable, "Delivery failed - retrying in 5 seconds.");
        //                    }
        //                    else
        //                    {
        //                        notificationEmailDetails.Update((int)NotificationEmailDetailss.FailedRecipient, $"Failed to deliver message to {ex.InnerExceptions[i].FailedRecipient}");
        //                    }
        //                }
        //            }
        //            catch (System.Exception ex)
        //            {
        //                notificationEmailDetails.Update((int)NotificationEmailDetailss.RetryIfBusy, $"Retry Busy {ex.Message.ToString()}");

        //            }

        //            this.notificationDbContext.NotificationEmailDetails.Add(notificationEmailDetails);
        //            this.notificationDbContext.SaveChanges();
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //}


    }
}