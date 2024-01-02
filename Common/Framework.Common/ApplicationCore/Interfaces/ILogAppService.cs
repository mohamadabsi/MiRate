using Framework.Core.CommonTables.Entities;
using Framework.Core.CommonTables.VM;
using PagedList.Core;
using System;
using System.Threading.Tasks;

namespace Framework.Common.Services
{
    public interface ILogAppService
    {
        void ClearLog();
        Task DeleteLogOlderThan5Days();
        Task<Log> GetLogById(Guid id);
        Task<IPagedList<Log>> GetLogs(LogFilter model);
    }
}