using Framework.Core.CommonTables.Services;
using Framework.Notifications.ViewModels;
using Framework.Notifications.Entities;
using Framework.Notifications.Data;
using System.Collections.Generic;
using Framework.Core.Extensions;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using Framework.Core.Contracts;
using Framework.Core.Contracts.Notifications;
using Framework.Core.Globalization;
using PagedList.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Framework.Core.Base;
using static Framework.Notifications.Services.EmailServiceAPI;

namespace Framework.Notifications.Services
{
    public class NotificationsManager : INotificationsManager
    {
        private readonly INotificationsRepository<NotificationQueue> _notificationQueueRepo;
        private readonly INotificationTemplateService _notificationTemplateService;
        private readonly IMapper _mapper;
        private readonly IEmailServiceAPI EmailService;
        private readonly ISmsService SmsService;
        private readonly INotificationSettingsService _notificationSettings;
        private readonly IAppSettingsService _appSettingsService;


        public NotificationsManager(
            INotificationsRepository<NotificationQueue> notificationQueueRepo,
            INotificationTemplateService notificationTemplateService,
             INotificationSettingsService notificationSettings,
            IAppSettingsService appSettingsService, IMapper mapper, IEmailServiceAPI _emailService, ISmsService _smsService)
        {
            _notificationTemplateService = notificationTemplateService;
            _notificationQueueRepo = notificationQueueRepo;
            _appSettingsService = appSettingsService;
            _notificationSettings = notificationSettings;
            _mapper = mapper;
            EmailService = _emailService;
            SmsService = _smsService;
        }


        public async Task AddNotificationEmailToQueueAsync(string templateName,
           Dictionary<string, string> placeHolders,
           List<string> to,
           List<string> cc = null,
           List<string> bcc = null,
           Guid? attachmentId = null, bool isImmediate = false )
        {
            var notificationQueue = await this.BuildEmailNotificationBodyAsync(templateName, placeHolders, NotificationTypes.Email);

            notificationQueue.To = to != null && to.Any() ? to.JoinAsString(",") : "";

            notificationQueue.Cc = cc != null && cc.Any() ? cc.JoinAsString(",") : "";

            notificationQueue.Bcc = bcc != null && cc.Any() ? bcc.JoinAsString(",") : "";

            notificationQueue.AttachmentId = attachmentId;

            await this._notificationQueueRepo.InsertAsync(notificationQueue, true);

            if (isImmediate)
            {
                await EnqueueEmail(notificationQueue);
            }

        }

        private async Task EnqueueSms(NotificationQueue message)
        {
            var smsMessage = message.ToSMSMessage(_notificationSettings);

            var response = await SmsService.SendSms(smsMessage);
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


        private async Task EnqueueEmail(NotificationQueue message)
        {

            var emailMessage = message.ToMailMessage(_notificationSettings);
            var notificationObj = new NotificationInfo();
            notificationObj.to.Add(message.To) ;
            notificationObj.cc.Add(message.Cc) ;
            notificationObj.body = emailMessage.Body;
            notificationObj.to.Add(message.To) ;
            notificationObj.subject = emailMessage.Subject;
            var response = await this.EmailService.SendNotification(notificationObj);

            var notificationQueue = this._notificationQueueRepo.GetById(message.Id);

            notificationQueue.IsActive = false;


            notificationQueue.SendErrorMessage = response.Status.ErrorCode + "/ " + response.Status.ErrorDesc + "/" + response.Status.Status.ToString() ;

            notificationQueue.LastSendDate = DateTime.Now;

            this._notificationQueueRepo.Update(notificationQueue, true);

        }
        public async Task AddNotificationSMSToQueueAsync(string templateName,
            Dictionary<string, string> placeHolders,
            List<string> to,bool isImmediate)
        {
           
            var notificationQueue = await this.BuildEmailNotificationBodyAsync(templateName, placeHolders, NotificationTypes.Sms);

            notificationQueue.To = to.JoinAsString(",");

            await this._notificationQueueRepo.InsertAsync(notificationQueue, true);

            if (isImmediate)
            {
                await EnqueueSms(notificationQueue);
            }

        }


        public List<LookupVM>  getAllSubject()
        {
            var data=   this._notificationQueueRepo.TableNoTracking.Include(a => a.NotificationType).DistinctBy(s => s.Subject).ToList();
            var result = data.Select(a => new LookupVM(a.Subject, a.Subject, a.Subject)).ToList();
            return result;
        }


        public async Task<IPagedList<NotificationQueueVM>> GetPagedListNotificationQueueSort(NotificationFilter filter)
        {
            IPagedList<NotificationQueueVM> finalResult = null;
            List<NotificationQueueVM> mappedList;
            IPagedList<NotificationQueueVM> finalPagedList = null;

            IQueryable<NotificationQueueVM> result = null;

            var NotificationsQueuequery = this._notificationQueueRepo.TableNoTracking.Include(a => a.NotificationType).Where(a => !a.IsDeleted).AsQueryable();
            if (!string.IsNullOrEmpty(filter.Subject))
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.Subject.Trim().ToLower().Contains(filter.Subject.Trim().ToLower()));
            }
            if (filter.SendDateFrom.HasValue && filter.SendDateTo.HasValue)
            {
                NotificationsQueuequery = NotificationsQueuequery
                    .Where(u => u.CreatedOn.Date >= filter.SendDateFrom.Value.Date && u.CreatedOn.Date <= filter.SendDateTo.Value.Date);
            }
            else
            {

                if (filter.SendDateFrom.HasValue)
                {
                    NotificationsQueuequery = NotificationsQueuequery.Where(u => u.CreatedOn.Date >= filter.SendDateFrom.Value.Date);
                }
                if (filter.SendDateTo.HasValue)
                {
                    NotificationsQueuequery = NotificationsQueuequery.Where(u => u.CreatedOn.Date <= filter.SendDateTo.Value.Date);
                }
            }

            if (filter.NotificationTypeId.HasValue)
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.NotificationTypeId == filter.NotificationTypeId);
            }


            if (filter.To.IsNotNullOrEmpty())
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.To.Trim().ToLower().Contains(filter.To.Trim().ToLower()));
            }

            if (filter.ColName == "Subject")
            {
                if (filter.IsDeccending == true)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderByDescending(n => n.Subject).Take(100);
                }

                if (filter.IsDeccending == false)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderBy(n => n.Subject).Take(100);
                }
            }


            if (filter.ColName == "To")
            {
                if (filter.IsDeccending == true)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderByDescending(n => n.To).Take(100);
                }

                if (filter.IsDeccending == false)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderBy(n => n.To).Take(100);
                }
            }

            if (filter.ColName == "NotificationType")
            {
                if (filter.IsDeccending == true)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderByDescending(n => n.LocalizedNotificationTypeName).Take(100);
                }

                if (filter.IsDeccending == false)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderBy(n => n.LocalizedNotificationTypeName).Take(100);
                }
            }


            if (filter.ColName == "SendDate")
            {
                if (filter.IsDeccending == true)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderByDescending(n => n.CreatedOn).Take(100);
                }

                if (filter.IsDeccending == false)
                {
                    result = null;
                    result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM
            {
                To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn = a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderBy(n => n.CreatedOn).Take(100);
                }
            }

            finalResult = result.ToPagedList(filter.PageNumber, filter.PageSize);

            mappedList = _mapper.Map<List<NotificationQueueVM>>(finalResult);

            finalPagedList = new StaticPagedList<NotificationQueueVM>(mappedList, finalResult);

            return finalPagedList;


        }

        public async Task<IPagedList<NotificationQueueVM>> GetPagedListNotificationQueue(NotificationFilter filter)
        {
            IPagedList<NotificationQueueVM> finalResult;
            List<NotificationQueueVM> mappedList;
            IPagedList<NotificationQueueVM> finalPagedList= null;



            var NotificationsQueuequery = this._notificationQueueRepo.TableNoTracking.Include(a=>a.NotificationType).Where(a => !a.IsDeleted).AsQueryable();
            if (!string.IsNullOrEmpty(filter.Subject))
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.Subject.Trim().ToLower().Contains(filter.Subject.Trim().ToLower()));
            }
            if (filter.SendDateFrom.HasValue && filter.SendDateTo.HasValue)
            {
                NotificationsQueuequery = NotificationsQueuequery
                    .Where(u => u.CreatedOn.Date >= filter.SendDateFrom.Value.Date && u.CreatedOn.Date <= filter.SendDateTo.Value.Date);
            }
            else { 

            if (filter.SendDateFrom.HasValue)
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.CreatedOn.Date >= filter.SendDateFrom.Value.Date);
            }
            if (filter.SendDateTo.HasValue)
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.CreatedOn.Date <= filter.SendDateTo.Value.Date);
            }
            }

            if (filter.NotificationTypeId.HasValue)
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.NotificationTypeId == filter.NotificationTypeId);
            }


            if (filter.To.IsNotNullOrEmpty())
            {
                NotificationsQueuequery = NotificationsQueuequery.Where(u => u.To.Trim().ToLower().Contains(filter.To.Trim().ToLower()));
            }

            var result = NotificationsQueuequery.Select(a =>
            new NotificationQueueVM 
            {   To = a.To,
                Message = a.Message,
                Cc = a.Cc,
                Subject = a.Subject,
                CreatedOn =  a.CreatedOn,
                LastSendDate = a.LastSendDate,
                NotificationTypeId = a.NotificationTypeId,
                LocalizedNotificationTypeName = CultureHelper.IsArabic ? a.NotificationType.NameAr : a.NotificationType.NameEn
            }
            ).OrderByDescending(n=>n.CreatedOn).Take(100);

            finalResult = result.ToPagedList(filter.PageNumber, filter.PageSize);

            mappedList = _mapper.Map<List<NotificationQueueVM>>(finalResult);

            finalPagedList = new StaticPagedList<NotificationQueueVM>(mappedList, finalResult);

            return finalPagedList;


        }

        private async Task<NotificationQueue> BuildEmailNotificationBodyAsync(string templateName, Dictionary<string, string> placeHolders, NotificationTypes notificationType)
        {
            var notification = new NotificationQueue(notificationType);

            var template = await this._notificationTemplateService.GetTemplateAsync(templateName, notificationType);

            if (template == null)
                return notification;

            var emailBodyEn = new StringBuilder(template.HTML);

            var emailBodyAr = new StringBuilder(template.HTMLAr);

            if (notificationType == NotificationTypes.Email)
            {

                emailBodyEn = await FillEmailLayoutAsync(emailBodyEn , emailBodyAr);
            }
            else
            {
                emailBodyEn = new StringBuilder(template.HTMLAr + "\n\n" +template.HTML);
            }
            ReplaceParameters(ref emailBodyEn, placeHolders);

            emailBodyEn = emailBodyEn.Replace("{InternalUrl}", this._notificationSettings.InternalUrl);

            emailBodyEn = emailBodyEn.Replace("{ExternalUrl}", this._notificationSettings.ExternalUrl);

            var subject = template.Subject.IsNullOrEmpty() ? $"{this._notificationSettings.EmailSubject} - {template.Subject}" : template.Subject;

            notification.Subject = subject;

            notification.Message = emailBodyEn.ToString();

            return notification;
        }

        private async Task<StringBuilder> FillEmailLayoutAsync(StringBuilder emailBodyEn , StringBuilder emailBodyAr)
        {
            var layoutTemplate = await this._notificationTemplateService.GetTemplateAsync(NotificationTemplates.EmailLayoutTemplate.ToString(), NotificationTypes.Email);

            var layoutBody = new StringBuilder(layoutTemplate.HTML);

            layoutBody = layoutBody.Replace("{body}", emailBodyEn.ToString());

            layoutBody = layoutBody.Replace("{bodyAr}", emailBodyAr.ToString());

            layoutBody = layoutBody.Replace("{ContactUsEmail}", this._notificationSettings.ContactUsEmail);

            layoutBody = layoutBody.Replace("{RootUrl}", this._notificationSettings.ApplicationUrl);

            layoutBody = layoutBody.Replace("{InternalUrl}", this._notificationSettings.InternalUrl);

            layoutBody = layoutBody.Replace("{ExternalUrl}", this._notificationSettings.ExternalUrl);

            return layoutBody;

        }
       
        private void ReplaceParameters(ref StringBuilder emailBody, Dictionary<string, string> parameters)
        {
            if (parameters == null || !parameters.Any())
                return;
            foreach (var item in parameters)
            {
                if (emailBody.ToString().IndexOf("{" + item.Key + "}") >= 0)
                    emailBody = emailBody.Replace("{" + item.Key + "}", item.Value);
            }
        }
    }
}

