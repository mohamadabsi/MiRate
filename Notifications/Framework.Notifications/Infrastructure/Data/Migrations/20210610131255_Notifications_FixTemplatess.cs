using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1802,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} مدير الإدارة\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم  بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1802,
                column: "HTMLAr",
                value: "المكرم UserFullNameAr} مدير الإدارة\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم  بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}");
        }
    }
}
