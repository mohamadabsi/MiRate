using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Framework.Notifications.Resources;

namespace Framework.Notifications.Entities
{
   public class NotificationEmailDetailsVM
    {
        public Guid Id { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.Host))]
        public string Host { get; set; }
        [Display(ResourceType =typeof(NotificationsResources),Name =nameof(NotificationsResources.UseDefaultCredentials))]
        public bool UseDefaultCredentials { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.SmtpPort))]
        public int SmtpPort { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.SmtpEnableSSL))]
        public bool SmtpEnableSSL { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.DeliveryMethod))]
        public string DeliveryMethod { get; set; }        
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.EmailFromAddress))]
        public string EmailFromAddress { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.EmailFromName))]
        public string EmailFromName { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.MailBody))]
        public string MailBody { get; set; }
        [Display(ResourceType =typeof(NotificationsResources),Name =nameof(NotificationsResources.MailFrom))]
        public string MailFrom { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.MailIsBodyHtml))]
        public bool MailIsBodyHtml { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.Subject))]
        public string Subject { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.To))]
        public string To { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.Cc))]
        public string Cc { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.Bcc))]        
        public string Bcc { get; set; }
        [Display(ResourceType =typeof(NotificationsResources),Name =nameof(NotificationsResources.SendStatusCode))]
        public int SendStatusCode { get; set; }
        [Display(ResourceType =typeof(NotificationsResources), Name =nameof(NotificationsResources.SendErrorMessage))]
        public string SendErrorMessage { get; set; }
        [Display(ResourceType =typeof(NotificationsResources),Name =nameof(NotificationsResources.LastSendDate))]
        public DateTime LastSendDate { get; set; }
        
    }
}
