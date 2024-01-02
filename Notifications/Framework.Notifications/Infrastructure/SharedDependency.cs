using AutoMapper;
using Framework.Core;
using Framework.Core.Utils;
using Framework.Notifications.Data;
using Microsoft.Extensions.Logging;

namespace Framework.Notifications.Infrastructure
{
    public interface ISharedDependency
    {
        IDateTimeHelper DateTimeHelper { get; }
        ILogger Logger { get; }
        IMapper Mapper { get; }
        INotificationsUnitOfWork UnitOfWork { get; }
    }

    public class SharedDependency : ISharedDependency
    {
        public SharedDependency(IMapper mapper,
                                IDateTimeHelper dateTimeHelper, 
                                INotificationsUnitOfWork unitOfWork)
        {
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.DateTimeHelper = dateTimeHelper;
        }

        public IMapper Mapper { get; }
        public ILogger Logger => ApplicationLogging.CreateLogger<SharedDependency>();

        public INotificationsUnitOfWork UnitOfWork { get; }

        public IDateTimeHelper DateTimeHelper { get; }
    }
}