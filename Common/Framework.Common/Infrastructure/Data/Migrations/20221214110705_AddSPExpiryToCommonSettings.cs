using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Common.Infrastructure.Data.Migrations
{
    public partial class AddSPExpiryToCommonSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Common",
                table: "SystemSetting",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedOn", "GroupName", "IsActive", "IsDeleted", "IsSecure", "IsSticky", "Name", "UpdatedBy", "UpdatedOn", "Value", "ValueType" },
                values: new object[] { 700, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "SupportProgramExpiryInMonths", null, null, "10", "int" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Common",
                table: "SystemSetting",
                keyColumn: "Id",
                keyValue: 700);
        }
    }
}
