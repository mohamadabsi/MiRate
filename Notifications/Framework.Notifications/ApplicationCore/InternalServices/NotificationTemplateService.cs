using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Data;
using Framework.Notifications.Data;
using Framework.Notifications.Entities;
using Framework.Notifications.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Framework.Core.CommonTables.Services
{
    public class NotificationTemplateService : INotificationTemplateService
    {
        private readonly INotificationsRepository<NotificationTemplate> _notificationTemplateRepository;

        public NotificationTemplateService(INotificationsRepository<NotificationTemplate> notificationTemplateRepository)
        {
            _notificationTemplateRepository = notificationTemplateRepository;
        }



        public async Task<NotificationTemplate> GetTemplateAsync(string key, NotificationTypes notificationType)
        {
            var template =
                await _notificationTemplateRepository.TableNoTracking.FirstOrDefaultAsync(n => n.NameEn.Trim() == key && n.NotificationTypeId == (int)notificationType);
            if (template == null)
            {
                throw new NotificationException(
                    $"The template '{key}' is not available, Check table common.NotificationTemplate");
            }

            return template;

        }
    }
}
