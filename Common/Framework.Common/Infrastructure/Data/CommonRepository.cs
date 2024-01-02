using Framework.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CommonRepository<TEntity> : EfCoreRepository2<CommonDbContext, TEntity> , IAppRepository2<TEntity>
        where TEntity : class
    {
        public CommonRepository(IDbContextFactory<CommonDbContext> dbContext) : base(dbContext)
        {
        }

        ICommonDbContext IEfCoreRepository<ICommonDbContext, TEntity>.DbContext => base.DbContext;
    }

    public interface IAppRepository2<TEntity> : IEfCoreRepository<ICommonDbContext, TEntity> where TEntity : class
    {
    }
}
     

