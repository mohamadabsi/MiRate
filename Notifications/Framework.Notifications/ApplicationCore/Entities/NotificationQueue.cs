using Framework.Core.Base;
using Framework.Core.Data;
using Framework.Core.DataAnnotations;
using Framework.Core.Extensions;
using Framework.Core.Notifications;
using Framework.Notifications.Services;
using Framework.Notifications.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Framework.Notifications.Entities
{

    public class NotificationQueue : FullAuditedEntityBase<Guid>
    {

        public NotificationQueue()
        {
        }

        public NotificationQueue(NotificationTypes notificationType)
        {
            this.NotificationTypeId = (int)notificationType;

            this.IsActive = true;
        }

        public string MessageId { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public int? SendStatusCode { get; set; }
        public string SendErrorMessage { get; set; }
        public DateTime? LastSendDate { get; set; }
        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
        [NotMapped]
        public bool IsFast { get; set; } 
        public Guid? AttachmentId { get; set; }

        public MailMessage ToMailMessage(INotificationSettingsService notificationSettings)
        {

            var mailMessage = new MailMessage
            {
                Body = this.Message,
                From = new MailAddress(notificationSettings.EmailFromAddress, notificationSettings.EmailFromName),
                IsBodyHtml = true,
                Subject = this.Subject
            };
            var to = this.To.Split(',').ToList();

            foreach (var item in to)
            {
                if (item.IsNotNullOrEmpty())
                {
                    mailMessage.To.Add(new MailAddress(item));

                }
            }

            return mailMessage;
        }

        public SmsMessage ToSMSMessage(INotificationSettingsService notificationSettings)
        {
            var smsMessage = new SmsMessage
            {
                Text = this.Message,
                Title = this.Subject,
                PhoneNumber = this.To
            };
            return smsMessage;
        }


        public enum NotificationQueueTypes 
        {
            [LookupLocalization("بريد إلكتروني", "Email")]
            Email = 100,
            [LookupLocalization("رسالة", "SMS")]
            SMS = 200,
            [LookupLocalization("إشعار تطبيق", "Mobile notification")]
            MobileNotification = 300,
            [LookupLocalization("إشعار موقع الكتروني", "Web notification")]
            WebNotification = 400,
        }
    }

}