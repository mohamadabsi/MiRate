using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesReasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تك بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تك بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.\r\n\r\n\r\n\r\n\r\nالأسباب :  {Reason}");
        }
    }
}
