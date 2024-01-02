// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationTemplate.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.Entities
{
    using Framework.Core.Base;
    using Framework.Core.DataAnnotations;

    #region usings

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    ///     The notification template.
    /// </summary>
    public class NotificationTemplate : LookupEntityBase
    {
        public int? ApplicationId { get; set; }

        [MaxLength(2000)]
        public string HTML { get; set; }
        [MaxLength(2000)]
        public string HTMLAr { get; set; }
        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }

        public string Subject { get; set; }
        public string SubjectAr { get; set; }
    }

    public enum NotificationTemplates
    {

        EmailLayoutTemplate = 100,

        EmailLoginVerification = 200,

        EmailResetPassword = 300,

        EmailConfirmEmailTemplate = 400,

        NewRequest = 500,

        NewTask = 600,

        RequestDecision = 700,

        InformationCompletion = 800,

        CreateNewEventTemplate = 900,

        AcceptEventTemplate = 1000,

        RejectEventTemplate = 1100,

        EventPermitTemplate = 1200,

        PortalMessageTemplate = 1300,

        [LookupLocalization("تم إرسال طلبك بنجاح", "Your request has been submitted")]
        Submitter_RequestSubmittedSucessfully = 1400,

        [LookupLocalization("تم إرسال طلب للمراجعة", "A request has been submitted for review")]
        Supervisor_RequestSubmittedWaitingForReview = 1500,

        [LookupLocalization("طلب جديد للدراسة", "You have a new request to study")]
        Reviewer_AssignedOnRequestToReview = 1600,

        [LookupLocalization("تم إرسال طلب للمراجعة", "A request has been submitted for review")]
        Supervisor_ReviewerApprovedTheRequest = 1700,

        [LookupLocalization("إرسال طلب للاعتماد", "A request has been submitted for approval")]
        Director_HasNewRequestToReview = 1800,

        [LookupLocalization("حالة طلب التسجيل", "Please review the registration request for some notes.")]
        Submitter_RequestNeedsMoreInfo = 1900,

        [LookupLocalization("حالة طلب التسجيل", "Request status")]
        Submitter_RequestRejected = 2000,

        [LookupLocalization("حالة طلب التسجيل", "Request status")]
        Submitter_RequestApproved = 2050,

        [LookupLocalization("حالة طلب التسجيل", "Request status")]
        Submitter_RequestRejectedStep2 = 2100,

        [LookupLocalization("إشعار بقرب انتهاء السجل التجاري", "CR pre expiration notification alert")]
        CRPreExpirationNotification = 2200,

        [LookupLocalization("إشعار بانتهاء السحل التجاري اليوم", "CR expiring notification alert")]
        CRExpiringNotification = 2210,

        [LookupLocalization("إشعار بانتهاء السجل التجاري", "CR expired notification alert")]
        CRExpiredNotification = 2220,

        [LookupLocalization("إشعار بقرب انتهاء صلاحية التسجيل", "Profile pre expiration notification alert")]
        ProfilePreExpirationNotification = 2230,

        [LookupLocalization("إشعار بانتهاء صلاحية التسجيل اليوم", "Profile expiring notification alert")]
        ProfileExpiringNotification = 2240,

        [LookupLocalization("إشعار بالنتهاء صلاحية التسجيل", "Profile expired notification alert")]
        ProfileExpiredNotification = 2250,

        [LookupLocalization("توثيق البريد الإلكتروني", "Email confirmation")]
        EmailCodeVerification = 2400,

        [LookupLocalization("توثيق رقم الهاتف", "Mobile confirmation")]
        NumberCodeVerification = 2500,

        [LookupLocalization("تم تصعيد الطلب", "Request escalated")]
        EscalationTemplate = 3000,

        [LookupLocalization("التذكير باتخاذ اجراء على المهمة", "Reminder to take action on the task")]
        EscalationReminderTemplate = 3100,

        [LookupLocalization("رسائل الشركات", "Companies messages notification")]
        CompaniesMessageNotification = 4000,

      

    }

    public enum WebNotificationTemplate
    {
    }


    public enum MobileTemplateNames
    {
    }

    public enum SmsTemplateNames
    {
        SmsLoginVerification
    }
}