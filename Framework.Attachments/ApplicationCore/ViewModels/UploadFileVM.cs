using Microsoft.AspNetCore.Http;
using System;

namespace Framework.Attachments.ViewModels
{
  public  class UploadFileVM
    {
        public int TypeId { get; set; }
        public IFormFile File { get; set; }

        public Guid? RequestId { get; set; }
        public Guid? AttachementId { get; set; }

    }

    public class UploadImageVM
    {
        //public string Image { get; set; }
        public IFormFile File { get; set; }

        public int TypeId { get; set; }

        public Guid? AttachementId { get; set; }
    }
}
