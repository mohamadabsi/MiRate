using Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace Framework.Attachments.Model
{

    [Table("Attachments", Schema = "Attachment")]
    public partial class Attachment :FullAuditedEntityBase<Guid>
    {
        public AttachmentContent AttachmentContent { get; set; }
      //  public AttachmentContent OldAttachmentContent { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the description ar.
        /// </summary>
        public string DescriptionAr { get; set; }


        public bool IsSecure { get; set; }


        /// <summary>
        /// Gets or sets the description en.
        /// </summary>
        public string DescriptionEn { get; set; }

        /// <summary>
        /// Gets or sets the extention.
        /// </summary>
        public string Extention { get; set; }

        internal void DeActivate()
        {
          //  this.IsActive = false; 
        }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        public byte[] Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the title ar.
        /// </summary>
        public string TitleAr { get; set; }

        /// <summary>
        /// Gets or sets the title en.
        /// </summary>
        public string TitleEn { get; set; }


        public int AttachmentTypeId { get; set; }

        public AttachmentType AttachmentType { get; set; }
        public Guid? RequestId { get; internal set; }
    }

    }
