using Framework.Attachments.Model;
using Framework.Core;
using Framework.Core.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Framework.Attachments.ViewModels
{
    public class MultiUploaderVM
    {
        public Guid RequestId { get; set; }

        public int TypeId { get; set; }

        public ViewModes ViewMode { get; set; }
        public IFormFile File { get; set; }

        public IList<AttachmentVM> Attachments { get; set; }

        public string TemplateName { get; set; }
        public string ImageUrl { get; set; }

    }
}
