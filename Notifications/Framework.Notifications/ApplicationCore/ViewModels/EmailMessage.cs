﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMessage.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.ViewModels
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    #endregion

    /// <summary>
    ///     The simple mail message.
    /// </summary>
    [Serializable]
    public class EmailMessage : NotificationMessageBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailMessage" /> class.
        /// </summary>
        public EmailMessage()
        {
            this.To = new List<string>();
        }
        public EmailMessage(
            List<string> to,
            List<string> cc,           
            string subject ,
            string body)
        {
            this.To = to;
            //this.From = from;
            //this.DisplayName = displayName;
            this.Body = body;
            this.Subject = subject;
        }
        /// <summary>
        ///     Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        ///     Gets or sets the from.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        ///     Gets or sets the reply to.
        /// </summary>
        public string ReplyTo { get; set; }

        /// <summary>
        ///     Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     Gets or sets the to.
        /// </summary>
        public List<string> To { get; set; }

        /// <summary>
        ///     The to mail message.
        /// </summary>
        /// <returns>
        ///     The <see cref="MailMessage" />.
        /// </returns>
        public MailMessage ToMailMessage()
        {
            var mailMessage = new MailMessage
                                  {
                                      Body = this.Body,
                                      From = new MailAddress(this.From, this.DisplayName),
                                      IsBodyHtml = true,
                                      Subject = this.Subject
                                  };

            foreach (var item in this.To)
            {
                mailMessage.To.Add(new MailAddress(item));
            }

            return mailMessage;
        }
    }
}