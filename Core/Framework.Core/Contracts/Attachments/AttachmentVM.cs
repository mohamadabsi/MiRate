using System;
using JetBrains.Annotations;

namespace Framework.Core.Contracts
{
    public class AttachmentVM
    {
        public string ErrorMessage { get; set; }

        public bool Success { get; set; }

        public Guid Id { get;  set; }

        public bool IsSecure { get; set; }

        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the description ar.
        /// </summary>
        public string DescriptionAr { get; set; }

        /// <summary>
        /// Gets or sets the description en.
        /// </summary>
        public string DescriptionEn { get; set; }

        /// <summary>
        /// Gets or sets the extention.
        /// </summary>
        public string Extention { get; set; }

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
        public byte[] Content { get; set; }
        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        [CanBeNull] public byte[]  OldContent { get; set; }
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

        public Guid? RequestId { get; set; }
    }

    }
