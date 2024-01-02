using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Framework.Attachments.Data;

namespace Framework.Attachments.Data
{
      public class AttachmentsRepository<TEntity> : EfCoreRepository<IAttachmentsDbContext, TEntity>, IAttachmentsRepository<TEntity>
        where TEntity : class
    {
        public AttachmentsRepository(IAttachmentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
     

