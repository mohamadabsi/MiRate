using Framework.Core.Data.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Attachments.Infrastructure.Data
{
    public interface ILogAuditUnitOfWork : IUnitOfWorkBase<ILogAuditDbContext>
    {


    }
}
  