using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixNotificationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "Notifications",
                table: "NotificationSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 10,
                column: "Value",
                value: "FALSE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 20,
                column: "Value",
                value: "FALSE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 30,
                column: "Value",
                value: "Tasjeel Tech");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 40,
                column: "Value",
                value: "exch-array.citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 50,
                column: "Value",
                value: "Tasjeeltech@citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 60,
                column: "Value",
                value: "AzswQ@123753@zizadqhhdone");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 70,
                column: "Value",
                value: "TRUE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 80,
                column: "Value",
                value: "587");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 90,
                column: "Value",
                value: "FALSE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 100,
                column: "Value",
                value: "Tasjeeltech@citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 110,
                column: "Value",
                value: "Tasjeel Tech");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 120,
                column: "Value",
                value: "Tasjeeltech@citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 130,
                column: "Value",
                value: "Tasjeel Tech");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 140,
                column: "Value",
                value: "http://localhost:44309/");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 100,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 200,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 300,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 400,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                schema: "Notifications",
                table: "NotificationSetting");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 100,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 200,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 300,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 400,
                column: "IsActive",
                value: false);
        }
    }
}
