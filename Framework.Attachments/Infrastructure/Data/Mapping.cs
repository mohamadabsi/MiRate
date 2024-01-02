using Framework.Attachments.Model;
using Framework.Core.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Attachments.Data
{
    public class AttachmentConfiguration : EntityTypeConfiguration<Attachment>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachment", "Attachment"); 
        }
    }
    public class AttachmentContentConfiguration : EntityTypeConfiguration<AttachmentContent>
    {
        public override void Configure(EntityTypeBuilder<AttachmentContent> builder)
        {
            builder.ToTable("AttachmentContent", "Attachment");

            builder.HasKey(sc => new
            {
                sc.AttachmentId,
            });
        }
    }

    public class AttachmentDownloadConfiguration : EntityTypeConfiguration<AttachmentDownload>
    {
        public override void Configure(EntityTypeBuilder<AttachmentDownload> builder)
        {
            builder.ToTable("AttachmentDownload", "Attachment");
        }
    }

    public class AttachmentTypeConfiguration : EntityTypeConfiguration<AttachmentType>
    {
        public override void Configure(EntityTypeBuilder<AttachmentType> builder)
        {
            builder.HasData(new AttachmentType(id: 100, allowedFilesExtension: "jpg,png,jpeg,gif,pdf,doc,docx,xls,xlsx,ppm,ppt,pptx,txt", maxSizeInMegabytes: 5));
            builder.HasData(new AttachmentType(id: 200, allowedFilesExtension: "jpg,png,jpeg", maxSizeInMegabytes: 5));
            builder.HasData(new AttachmentType(id: 300, allowedFilesExtension: "jpg,png,jpeg", maxSizeInMegabytes: 5));
            builder.HasData(new AttachmentType(id: 400, allowedFilesExtension: "xls,xlsx", maxSizeInMegabytes: 10));


        }
    }

}
