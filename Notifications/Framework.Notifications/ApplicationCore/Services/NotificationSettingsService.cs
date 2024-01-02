// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationsManager.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Framework.Core.Contracts;
using Framework.Core.Data;
using Framework.Notifications.Data;
using Framework.Notifications.Entities;
using System.Collections.Generic;
using System.Linq;
namespace Framework.Notifications.Services
{
    internal class NotificationSettingsService : INotificationSettingsService
    {
        private IList<NotificationSetting> notificationSettings { get; set; }
        private readonly INotificationsRepository<NotificationSetting> notificationSettingRepository;
        private readonly IAppSettingsService appSettingsService;

        public NotificationSettingsService(INotificationsRepository<NotificationSetting> notificationSettingRepository,
                                           IAppSettingsService appSettingsService)
        {
            this.notificationSettingRepository = notificationSettingRepository;
            this.appSettingsService = appSettingsService;
            this.notificationSettings = this.notificationSettingRepository.TableNoTracking. ToList();
        }
        string INotificationSettingsService.EmailFromName => this.GetValue(nameof(INotificationSettingsService.EmailFromName));

        string INotificationSettingsService.EmailFromAddress => this.GetValue(nameof(INotificationSettingsService.EmailFromAddress));

        string INotificationSettingsService.GoogleFCMSenderId => this.GetValue(nameof(INotificationSettingsService.GoogleFCMSenderId));

        string INotificationSettingsService.IsSmtpAuthenticated => this.GetValue(nameof(INotificationSettingsService.IsSmtpAuthenticated));

        string INotificationSettingsService.SenderId => this.GetValue(nameof(INotificationSettingsService.SenderId));

        string INotificationSettingsService.ServerKey => this.GetValue(nameof(INotificationSettingsService.ServerKey));

        bool INotificationSettingsService.SmtpEnableSSL => bool.Parse(this.GetValue(nameof(INotificationSettingsService.SmtpEnableSSL)));

        string INotificationSettingsService.SmtpPassword => this.GetValue(nameof(INotificationSettingsService.SmtpPassword));

        int INotificationSettingsService.SmtpPort => int.Parse(this.GetValue(nameof(INotificationSettingsService.SmtpPort)));

        string INotificationSettingsService.SmtpUserName => this.GetValue(nameof(INotificationSettingsService.SmtpUserName));

        string INotificationSettingsService.SmtpServer => this.GetValue(nameof(INotificationSettingsService.SmtpServer));
      
        string INotificationSettingsService.ContactUsEmail => this.GetValue(nameof(INotificationSettingsService.ContactUsEmail));

        string INotificationSettingsService.GoogleFCMServerKey => this.GetValue(nameof(INotificationSettingsService.GoogleFCMServerKey));

        string INotificationSettingsService.EmailSubject => this.GetValue(nameof(INotificationSettingsService.EmailSubject));

        string INotificationSettingsService.ApplicationUrl => appSettingsService.ExternalUrl;

        string INotificationSettingsService.ExternalUrl => appSettingsService.ExternalUrl;

        string INotificationSettingsService.InternalUrl => appSettingsService.InternalUrl;


        public string ApplicationId { get; set; }

        public string GetValue(string key)
        {
            var query = this.notificationSettings.Where(s => s.Key.Trim() == key.Trim());

            if(!string.IsNullOrEmpty(this.ApplicationId))
            {
                query = query.Where(s =>!string.IsNullOrEmpty(s.ApplicationId) 
                && s.ApplicationId.ToLower().Trim() == ApplicationId.ToLower().Trim());
            }
            var setting = query.FirstOrDefault();

            if(setting == null)
                setting= this.notificationSettings.FirstOrDefault(s => s.Key == key);

            return setting?.Value;
        }


    }
}