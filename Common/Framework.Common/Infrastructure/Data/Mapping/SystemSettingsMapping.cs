using Framework.Core.CommonTables.Entities;
using Framework.Core.Contracts;
using Framework.Core.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Framework.Common.Infrastructure.Data.Mapping
{
    public class SystemSettingsMapping : EntityTypeConfiguration<SystemSetting>
    {
        public override void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            builder.ToTable(nameof(SystemSetting), "Common");

            builder.HasData(new SystemSetting(100, nameof(IAppSettingsService.MockDate), "bool", "true", "", false, false));

            builder.HasData(new SystemSetting(200, nameof(IAppSettingsService.CurrentDate), "DateTime", new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified).ToString(), "", false, false));

            builder.HasData(new SystemSetting(300, nameof(IAppSettingsService.MockUser), "bool", "true", "", false, false));

            builder.HasData(new SystemSetting(400, nameof(IAppSettingsService.MockDataBase), "bool", "false", "", false, false));

            builder.HasData(new SystemSetting(500, nameof(IAppSettingsService.ExternalUrl), "string", "https://regtech.sure.com.sa/", "", false, false));

            builder.HasData(new SystemSetting(600, nameof(IAppSettingsService.InternalUrl), "string", "https://appregtech.sure.com.sa/", "", false, false));
            builder.HasData(new SystemSetting(700, nameof(IAppSettingsService.SupportProgramExpiryInMonths), "int", "10", "", false, false));

        }
    }
}
