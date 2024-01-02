using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Common.Infrastructure.Data.Migrations
{
    public partial class Common_SetUrls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "SystemSetting",
                keyColumn: "Id",
                keyValue: 500,
                column: "Value",
                value: "https://regtech.sure.com.sa/");

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "SystemSetting",
                keyColumn: "Id",
                keyValue: 600,
                column: "Value",
                value: "https://appregtech.sure.com.sa/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "SystemSetting",
                keyColumn: "Id",
                keyValue: 500,
                column: "Value",
                value: "false");

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "SystemSetting",
                keyColumn: "Id",
                keyValue: 600,
                column: "Value",
                value: "false");
        }
    }
}
