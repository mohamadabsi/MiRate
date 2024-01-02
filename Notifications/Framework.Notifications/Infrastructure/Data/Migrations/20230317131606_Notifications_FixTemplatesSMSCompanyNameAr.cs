using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesSMSCompanyNameAr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تك لتعديل الملاحظات الواردة على الطلب {RequestTypeAr} في الهيئة عبر الرابط التالي: {ExternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تك بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.\r\n" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تك لتعديل الملاحظات الواردة على الطلب {RequestTypeAr} في الهيئة عبر الرابط التالي: {ExternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CST is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تك بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.\r\n" });
        }
    }
}
