using System.Threading.Tasks;

namespace Framework.Notifications.Services
{
    public interface IEmailServiceAPI
    {
        Task<string> OAuthToken();
        Task<EmailServiceAPI.NotificationResponse> SendNotification(EmailServiceAPI.NotificationInfo notificationInfo);
    }
}
