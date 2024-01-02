using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesReasonsCancelReject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CST is rejected , You can review your request via the following link: {ExternalUrl}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CST is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}");
        }
    }
}
