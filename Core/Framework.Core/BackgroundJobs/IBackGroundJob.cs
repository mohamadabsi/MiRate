using System.Threading.Tasks;

namespace Framework.Core.BackgroundJobs
{
    public interface IBackGroundJob
    {
        string CronExpression { get; }
        Task Execute();

    }

}
