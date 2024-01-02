using System;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base;
using JetBrains.Annotations;

namespace Framework.Attachments.Model
{

    public class AttachmentContent :EntityBase
    {
        
        public Guid AttachmentId { get; set; }

        public Attachment Attachment { get; set; }

        public byte[] Content { get; set; }
        [CanBeNull] public byte[] OldContent { get; set; }
    }
}
