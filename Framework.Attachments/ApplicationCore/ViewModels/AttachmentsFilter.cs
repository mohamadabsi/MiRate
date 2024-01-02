using Framework.Attachments.Model;
using Framework.Core.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Attachments.ViewModels
{
    public class AttachmentsFilter:FilterBase
    {
              public AttachmentTypes? AttachmentType { get; set; }

             public string FileName { get; set; }

              public int? EngagementGroupId { get; set; }

               public string Extention { get; set; }

             public DateTime? CreatedOnAfter { get; set; }

             public DateTime? CreatedOnBefore { get; set; }

                public string CreatedBy { get; set; }

        //public DateTime? CreatedOn { get; set; }

    }
}
