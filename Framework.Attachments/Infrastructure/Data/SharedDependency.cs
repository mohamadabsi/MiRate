using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Attachments.Data
{
    public class AttachmentsSharedDependency
    {
        private readonly IMapper mapper;
        private readonly IAttachmentsUnitOfWork unitOfWork;
 
        public AttachmentsSharedDependency(IMapper mapper, IAttachmentsUnitOfWork unitOfWork )
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
           // this.logger = logger;
        }

        public IMapper Mapper => mapper;

        public IAttachmentsUnitOfWork UnitOfWork => unitOfWork;

    }
}
