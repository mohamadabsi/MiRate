using AutoMapper;
using Framework.Attachments.Model;
using Framework.Core.Contracts;

namespace Framework.Attachments
{
    public class AttachmensMapper : Profile
    {
        public AttachmensMapper()
        {
            this.CreateMap<Attachment, AttachmentVM>().ReverseMap();
            this.CreateMap<AttachmentVM, Attachment>().ReverseMap();
            this.CreateMap<AttachmentDownload, AttachmentDownloadVM>().ReverseMap();       
        }
    }
}

