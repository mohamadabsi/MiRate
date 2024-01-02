using Framework.Core.CommonTables.Entities;
using Framework.Core.CommonTables.VM;
using Framework.Core.Extensions;
using Infrastructure.Data;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Common.Services
{
    public class LogAppService : ILogAppService
    {
        private readonly CommonRepository<Log> _logRepository;
 
        public LogAppService(CommonRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IPagedList<Log>> GetLogs(LogFilter model)
        {
            var filters = new List<Expression<Func<Log, bool>>>();


            Expression<Func<Log, bool>> loglvl = r =>
                   (r.LogLevel.Equals("Error"));
            filters.Add(loglvl);

            if (model.LogLevel.IsNullOrEmpty())
            {
                Expression<Func<Log, bool>> dateFilter = r =>
                    (r.LogLevel.Equals("Error"));
                filters.Add(dateFilter);

            }
            else if (model.DateFrom.HasValue)
            {
                Expression<Func<Log, bool>> dateFilter = r =>
                    (r.Date.Date >= model.DateFrom.Value.Date);
                filters.Add(dateFilter);

            }
            else if (model.DateTo.HasValue)
            {
                Expression<Func<Log, bool>> dateFilter = r =>
                    (r.Date.Date <= model.DateTo.Value.Date);
                filters.Add(dateFilter);

            }

            if (!model.UserName.IsNullOrEmpty())
            {
                Expression<Func<Log, bool>> userNameFilter = r => r.UserName.Contains(model.UserName);
                filters.Add(userNameFilter);
            }

            if (!model.LogLevel.IsNullOrEmpty())
            {
                Expression<Func<Log, bool>> logLevelFilter = r => r.LogLevel == model.LogLevel;
                filters.Add(logLevelFilter);
            }


            var result = _logRepository.SearchWithFilters
            (
                model.PageNumber,
                50,
                a => a.Take(1000).OrderByDescending(b => b.Date),
                filters
            );

           
            var items =
                new StaticPagedList<Log>(
                    result,
                    result.PageNumber,
                    100,
                    result.TotalItemCount);

            return await Task.FromResult(items);

        }

        public async Task<Log> GetLogById(Guid id)
        {
            return await _logRepository.GetByIdAsync(id);
        }

        public void ClearLog()
        {
           // _logRepository.DbContext.ExecuteSqlCommand($"TRUNCATE TABLE common.Log");
        }

        public async Task DeleteLogOlderThan5Days()
        {

            await _logRepository.DeleteAsync(l => l.Date <= DateTime.Now.AddDays(-5));
        }
    }
}
