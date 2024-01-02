using FluentValidation;
using Framework.Core.Application.Validators;
using Framework.Core.Contracts.Notifications;
using Localization;
using Microsoft.Extensions.Localization;

namespace Framework.Notifications.Services
{
    public class NotificationFilterValidator : AbstractValidator<NotificationFilter>
    {
        public NotificationFilterValidator(IStringLocalizer<AppResources> AppLocalizer)
        {
            RuleFor(m => m.SendDateFrom)
                .BeforeToDate(m => m.SendDateTo, AppLocalizer)
                .When(m => m.SendDateFrom.HasValue && m.SendDateTo.HasValue);
        }
    }
}
