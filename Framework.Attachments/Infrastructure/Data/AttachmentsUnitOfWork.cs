using Framework.Core.Data;
using Framework.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Framework.Core.Data.Uow;

namespace Framework.Attachments.Data
{
      public sealed class AttachmentsUnitOfWork : UnitOfWorkBase<IAttachmentsDbContext>, IAttachmentsUnitOfWork
    {
        public AttachmentsUnitOfWork(AttachmentsDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,httpContextAccessor)
        {
        }
    }    
}
