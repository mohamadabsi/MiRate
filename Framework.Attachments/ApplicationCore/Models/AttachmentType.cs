using Framework.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Attachments.Model
{
    /// <summary>
    ///     The attachment type.
    /// </summary>
    [Table("AttachmentType", Schema = "Attachment")]
    public class AttachmentType : LookupEntityBase
    {
        public AttachmentType() { }
        public AttachmentType(int id, string allowedFilesExtension, double maxSizeInMegabytes)
        {
            IsActive = true;
            AllowedFilesExtension = allowedFilesExtension;
            MaxSizeInMegabytes = maxSizeInMegabytes;
            IsImage = false;
            Id = id;
            //Description = $@"
            //The file allowed extensions are: {AllowedFilesExtension} only.</br>
            //The file size must be less than {maxSizeInMegabytes} MB.
            //    ";
        }
       

        public AttachmentType(int id, string allowedFilesExtension, double maxSizeInMegabytes, int? imageMaxHeight, int? imageMaxWidth) : this(id, allowedFilesExtension, maxSizeInMegabytes)
        {
            IsActive = true;
            ImageMaxHeight = imageMaxHeight;
            ImageMaxWidth = imageMaxWidth;
            IsImage = true;
            //Description = $@"
            //The image allowed extensions are: {AllowedFilesExtension} only.</br>
            //The image size must be less than {maxSizeInMegabytes} MB.</br>
            //The image height must be less less than {ImageMaxHeight} pixel.</br>
            //The image width must be less than {ImageMaxWidth} pixel.
            //";
        }

        /// <summary>
        ///     Gets or sets the allowed files extension.
        /// </summary>

        public string AllowedFilesExtension { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>

        public string Code { get; set; }
        /// <summary>
        ///     Gets or sets the image max height.
        /// </summary>
        public int? ImageMaxHeight { get; set; }

        /// <summary>
        ///     Gets or sets the image max width.
        /// </summary>
        public int? ImageMaxWidth { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is image.
        /// </summary>
        public bool IsImage { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is mandatory.
        /// </summary>
        public bool IsMandatory { get; set; }

        /// <summary>
        ///     Gets or sets the max size in megabytes.
        /// </summary>
        public double MaxSizeInMegabytes { get; set; }

        public new string Description { get { return $"the allowed extensions are ({AllowedFilesExtension}) with maximum {MaxSizeInMegabytes} MB"; } }



    }

    public enum AttachmentTypes
    {
        Default = 100,
        EvisaPersonalImage = 200,
        AccreditationPassportAttachmentId = 300,
        DelegatesReport = 400
    }

}

