using Framework.Notifications.Entities;
using Framework.Notifications.ViewModels;
using System.Threading.Tasks;

namespace Framework.Core.CommonTables.Services
{
    public interface INotificationTemplateService
    {
        Task<NotificationTemplate> GetTemplateAsync(string key, NotificationTypes notificationType);
    }
}