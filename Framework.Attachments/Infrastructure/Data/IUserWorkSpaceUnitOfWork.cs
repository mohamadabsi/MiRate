using System;
using Framework.Core.Data.Uow;
using Microsoft.EntityFrameworkCore;

namespace Framework.Attachments.Data
{

    public interface IAttachmentsUnitOfWork : IUnitOfWorkBase<IAttachmentsDbContext>
    {


    }
}
