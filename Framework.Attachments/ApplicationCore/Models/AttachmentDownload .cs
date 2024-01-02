using Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Attachments.Model
{
    [Table("AttachmentDownload", Schema = "Attachment")]
    public class AttachmentDownload:FullAuditedEntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AttachmentId { get; set; }
    }
}
