using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Attachments.Model;
using Framework.Attachments.ViewModels;
using Framework.Core.Contracts;
using PagedList.Core;

namespace Framework.Attachments
{
    public interface IAttachmentsService
    {
        //AttachmentVM SaveFile(AttachmentVM attachment);
        AttachmentVM UpdateFile(AttachmentVM attachmentVM);
        MultiUploaderVM GetUploaderVM(Guid requestId, int typeId, string templateName);
        //AttachmentVM GetAttachment(Guid? attachmentId);
        byte[] GetAttachmentContent(Guid attachmentId);
        IPagedList<AttachmentVM> GetAttachments(AttachmentsFilter attachmentsFilter);
        void DeleteAttachment(Guid attachmentId);
        AttachmentVM GetAttachmentMetaData(Guid? attachmentId, AttachmentTypes type);
        void UpdateRequestId(Guid requestId, IEnumerable<Guid> enumerable);
        //string GetAttachmentBase64(Guid attachmentId);
        string GetAttachmentUrl(Guid attachmentId, string fileDownloadBaseUrl = "");
        bool IsAttachmentByGroupContainAnyAttachment(Guid attachmentGroupId);
        List<AttachmentVM> GetAttachmentByGroupId(Guid attachmentGroupId);
        AttachmentVM GetFileByName(string fileName);
        Task<AttachmentDownloadVM> DownlaodBy(AttachmentDownloadVM vm);

    }

}
