using Framework.Core.CommonTables.Entities;
using Framework.Core.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Common.Infrastructure.Data.Mapping
{
    public class LogMapping : EntityTypeConfiguration<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable(nameof(Log), "Logs");
            builder.Property(l=>l.Id).HasDefaultValueSql("newid()");
            builder.Property(l=>l.IsActive).HasDefaultValueSql("1");
            builder.Property(l => l.IsDeleted).HasDefaultValueSql("0");
         }
    }
}
