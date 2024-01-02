using Framework.Attachments.Model;
using Framework.Core;
using Framework.Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace Framework.Attachments.ViewModels
{
    public class UploaderVM
    {
       
        public string RequestId { get; set; }

        public int TypeId { get; set; }

        public ViewModes ViewMode { get; set; }
        public bool ViewImage { get; set; }

        public IFormFile File { get; set; }

        public AttachmentVM Attachment { get; set; }

        public string TemplateName { get; set; }
    }
}
