using Framework.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text;

namespace Framework.Notifications.Entities
{
  
    public class NotificationEmailDetails : FullAuditedEntityBase<Guid>
    {
        #region NotificationEmailDetails Constractor
        public NotificationEmailDetails()
        {

        }
       
        public NotificationEmailDetails(string host,
            bool useDefaultCredentials, int smtpPort,
            bool smtpEnableSSL, string deliveryMethod,
            string smtpUserName, string smtpPassword,
            string emailFromAddress, string emailFromName,
            string mailBody,
            string mailFrom,
            bool mailIsBodyHtml,
            string subject ,
            string to,
            string cc,
            string bcc
            )
        {
            Host = host;
            UseDefaultCredentials = useDefaultCredentials;
            SmtpPort = smtpPort;
            SmtpEnableSSL = smtpEnableSSL;
            DeliveryMethod = deliveryMethod;
            SmtpUserName = smtpUserName;
            SmtpPassword = smtpPassword;
            EmailFromAddress = emailFromAddress;
            EmailFromName = emailFromName;
            MailBody = mailBody;
            MailFrom = mailFrom;    
            MailIsBodyHtml = mailIsBodyHtml;
            Subject = subject;
            To = to;
            Cc = cc;
            Bcc = bcc;
            LastSendDate = DateTime.Now;
            SendErrorMessage = "Mail sent successfully";
            SendStatusCode = 200;
        }
        #endregion

        #region Update Method
        internal void Update(int sendStatusCode, string sendErrorMessage)
        {
            SendErrorMessage = sendErrorMessage;

            if ((int)NotificationEmailDetailss.MailboxBusy == sendStatusCode)
            {
                SendStatusCode = (int)NotificationEmailDetailss.MailboxBusy;
            }
            else
            if ((int)NotificationEmailDetailss.MailboxUnavailable == sendStatusCode)
            {
                SendStatusCode = (int)NotificationEmailDetailss.MailboxUnavailable;
            }
            else
            if ((int)NotificationEmailDetailss.FailedRecipient == sendStatusCode)
            {
                SendStatusCode = (int)NotificationEmailDetailss.FailedRecipient;
            }
            else
            if ((int)NotificationEmailDetailss.MailboxBusy == sendStatusCode)
            {
                SendStatusCode = (int)NotificationEmailDetailss.MailboxBusy;
            }

            LastSendDate = DateTime.Now;
        }
        #endregion
        public MailMessage ToMailMessage()
        {
            var mailMessage = new MailMessage
            {
                Body = this.MailBody,
                From = new MailAddress(this.EmailFromAddress, this.EmailFromName),
                IsBodyHtml = true,
                Subject = this.Subject
            };

            foreach (var item in this.To.Split(','))
            {
                mailMessage.To.Add(new MailAddress(item));
            }

            return mailMessage;
        }
        #region Properties get; set;

        public Guid Id { get; set; }
        public string Host { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public int SmtpPort { get; set; }
        public bool SmtpEnableSSL { get; set; }
        public string DeliveryMethod { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string EmailFromAddress { get; set; }
        public string EmailFromName { get; set; }
        public string MailBody { get; set; }
        public string MailFrom { get; set; }
        public bool MailIsBodyHtml { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }        
        public int SendStatusCode { get; set; }
        public string SendErrorMessage { get; set; }
        public DateTime LastSendDate { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }

    #region NotificationEmailDetailss Enum
    public enum NotificationEmailDetailss
    {
        Failed=500,
        Successfully = 200,
        MailboxBusy = 30,
        MailboxUnavailable = 40,
        FailedRecipient = 50,
        RetryIfBusy = 60

    }
    #endregion
}
