using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Framework.Attachments.Data
{
   public interface IAttachmentsRepository<TEntity> : IEfCoreRepository<IAttachmentsDbContext, TEntity> where TEntity :class
    {
    }
}
