// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationsManager.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.Services
{
    public interface INotificationSettingsService
    {
        string EmailFromName { get; }
        string EmailFromAddress { get; }
        string GoogleFCMSenderId { get; }
        string IsSmtpAuthenticated { get; }
        string SenderId { get; }
        string ServerKey { get; }
        bool SmtpEnableSSL { get; }
        string SmtpPassword { get; }
        int SmtpPort { get; }
        string SmtpUserName { get; }
        string SmtpServer { get; }
        string GoogleFCMServerKey { get; }
        string EmailSubject { get; }
        string ContactUsEmail { get;  }

        string ApplicationId { get; set; }
        string ApplicationUrl { get;  }
        string ExternalUrl { get; }
        string InternalUrl { get; }
    }
}