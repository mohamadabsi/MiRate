using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2502,
                column: "Subject",
                value: "Mobile confirmation");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3001,
                column: "Subject",
                value: "Request escalated");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3002,
                column: "Subject",
                value: "Request escalated");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3101,
                columns: new[] { "Subject", "SubjectAr" },
                values: new object[] { "Reminder to take action on the task", "التذكير باتخاذ اجراء على المهمة" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3102,
                columns: new[] { "Subject", "SubjectAr" },
                values: new object[] { "Reminder to take action on the task", "التذكير باتخاذ اجراء على المهمة" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 4001,
                column: "Subject",
                value: "Companies messages notification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2502,
                column: "Subject",
                value: "Mobile Confirmation");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3001,
                column: "Subject",
                value: "Request Escalated");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3002,
                column: "Subject",
                value: "Request Escalated");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3101,
                columns: new[] { "Subject", "SubjectAr" },
                values: new object[] { "Request Escalated", "تم تصعيد الطلب" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 3102,
                columns: new[] { "Subject", "SubjectAr" },
                values: new object[] { "Request Escalated", "تم تصعيد الطلب" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 4001,
                column: "Subject",
                value: "Companies Messages Notification");
        }
    }
}
