using Framework.Core.BackgroundJobs;
using Framework.Notifications.Data;
using Framework.Notifications.Entities;
using Framework.Notifications.Services;
using Framework.Notifications.ViewModels;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Framework.Notifications.Services.EmailServiceAPI;

namespace Framework.Notifications.Infrastructure.BackgroundJobs
{
    public class NotificationJob : IBackGroundJob
    {
        public string CronExpression => "*/5 * * * *";


        private readonly INotificationsRepository<NotificationQueue> _notificationQueueRepo;
        private readonly INotificationSettingsService _notificationSettings;
        private readonly IEmailServiceAPI _emailService;
        private readonly ISmsService _smsService;
        private readonly ISharedDependency sharedDependency;

        public NotificationJob(IServiceProvider serviceProvider)
        {
            this._notificationSettings = serviceProvider.GetService<INotificationSettingsService>();
            this._notificationQueueRepo = serviceProvider.GetService<INotificationsRepository<NotificationQueue>>();
            this._emailService = serviceProvider.GetService<IEmailServiceAPI>();
            this._smsService = serviceProvider.GetService<ISmsService>();
            this.sharedDependency = (ISharedDependency)serviceProvider.GetService(typeof(ISharedDependency));

        }

        [DisableConcurrentExecution(timeoutInSeconds: 5 * 60)]
        public async Task Execute()
        {
            await this.SendPendingNotifications();
        }

        private async Task SendPendingNotifications()
        {
            var notificationQueueQuery = this._notificationQueueRepo.TableNoTracking;

            notificationQueueQuery = notificationQueueQuery.Where(nq => nq.IsActive);

            notificationQueueQuery = notificationQueueQuery.Where(nq => !nq.IsDeleted);

            notificationQueueQuery = notificationQueueQuery.Where(nq => !string.IsNullOrEmpty(nq.To));

            notificationQueueQuery = notificationQueueQuery.Where(nq => !nq.SendStatusCode.HasValue);
            //TODO
            notificationQueueQuery = notificationQueueQuery.Where(nq => nq.CreatedOn >= DateTime.Now.AddDays(-1));

            if (notificationQueueQuery.Any())
            {
                notificationQueueQuery = notificationQueueQuery.OrderBy(nq => nq.CreatedOn).Take(500);

                var list = await notificationQueueQuery.OrderBy(nq => nq.CreatedOn).ToListAsync();

                foreach (var item in list)
                {
                    try
                    {
                        if (item.NotificationTypeId == (int)NotificationTypes.Email)
                            await this.EnqueueEmail(item);

                        else if (item.NotificationTypeId == (int)NotificationTypes.Sms)
                            await this.EnqueueSms(item);
                    }
                    catch   (Exception ex)
                    {
                        this.sharedDependency.Logger.Log(LogLevel.Error,ex, "NotificationJob_SendPendingNotifications");
                    }
                }
            }

        }



        public async Task EnqueueEmail(NotificationQueue message)
        {
           
            var emailMessage = message.ToMailMessage(_notificationSettings);

            var notificationObj = new NotificationInfo();
            notificationObj.to.Add(message.To);
            notificationObj.cc.Add(message.Cc);
            notificationObj.body = emailMessage.Body;
            notificationObj.to.Add(message.To);
            notificationObj.subject = emailMessage.Subject;
            var response = await this._emailService.SendNotification(notificationObj);

            var notificationQueue = this._notificationQueueRepo.GetById(message.Id);

            notificationQueue.IsActive = false;


            notificationQueue.SendErrorMessage = response.Status.ErrorCode + "/ " + response.Status.ErrorDesc + "/" + response.Status.Status.ToString();

            notificationQueue.LastSendDate = DateTime.Now;

            this._notificationQueueRepo.Update(notificationQueue, true);

        }

        private async Task EnqueueSms(NotificationQueue message)
        {
            var smsMessage = message.ToSMSMessage(_notificationSettings);

            var response = await _smsService.SendSms(smsMessage);

            var notificationQueue = _notificationQueueRepo.GetById(message.Id);

            if (response == null)
                return;

            if (response.Errors.Any())
            {
                notificationQueue.SendErrorMessage = string.Join("", response.Errors);

            }
            if (response.ErrorsCount == 0)
            {
                notificationQueue.IsActive = false;
            }

            notificationQueue.LastSendDate = DateTime.Now;

            _notificationQueueRepo.Update(notificationQueue, true);

        }


    }
}
