using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Common.Infrastructure.Data.Migrations
{
    public partial class Common_InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.CreateTable(
                name: "SystemSetting",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSecure = table.Column<bool>(type: "bit", nullable: false),
                    IsSticky = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSetting", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "SystemSetting",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedOn", "GroupName", "IsActive", "IsDeleted", "IsSecure", "IsSticky", "Name", "UpdatedBy", "UpdatedOn", "Value", "ValueType" },
                values: new object[,]
                {
                    { 100, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "MockDate", null, null, "true", "bool" },
                    { 200, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "CurrentDate", null, null, "5/29/2021 12:00:00 AM", "DateTime" },
                    { 300, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "MockUser", null, null, "true", "bool" },
                    { 400, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "MockDataBase", null, null, "false", "bool" },
                    { 500, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "ExternalUrl", null, null, "false", "string" },
                    { 600, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, false, false, false, "InternalUrl", null, null, "false", "string" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSetting",
                schema: "Common");
        }
    }
}
