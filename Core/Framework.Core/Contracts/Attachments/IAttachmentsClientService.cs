using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Contracts
{

    public interface IAttachmentsClientService
    {
        AttachmentVM SaveFile(AttachmentVM attachment);

        AttachmentVM GetAttachment(Guid? attachmentId);

        string GetAttachmentBase64(Guid attachmentId);
    }
}
