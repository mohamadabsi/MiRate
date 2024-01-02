using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesSMSCompanyNameArV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2202,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\nتحية طيبة،\r\nيرجى العلم أنه سيتم تعليق الملف التعريفي للشركة بسبب قرب انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.\r\n \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2212,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\nتحية طيبة،\r\nيرجى العلم أنه غدا سيتم تعليق الملف التعريفي للشركة بسبب انتهاء صلاحية السجل التجاري اليوم.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات. \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2222,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\nتحية طيبة،\r\n  يرجى العلم أنه تم  تعليق الملف التعريفي للشركة بسبب   انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لإعادة تفعيل ملف الشركة\"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2232,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \r\n \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2242,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2252,
                column: "HTMLAr",
                value: "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyNameAr}\r\nGreetings,\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the registration.\r\nSo please login to the portal to apply profile renew request.\"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2202,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه سيتم تعليق الملف التعريفي للشركة بسبب قرب انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.\r\n \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2212,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه غدا سيتم تعليق الملف التعريفي للشركة بسبب انتهاء صلاحية السجل التجاري اليوم.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات. \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2222,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\n  يرجى العلم أنه تم  تعليق الملف التعريفي للشركة بسبب   انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لإعادة تفعيل ملف الشركة\"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2232,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \r\n \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2242,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2252,
                column: "HTMLAr",
                value: "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the registration.\r\nSo please login to the portal to apply profile renew request.\"");
        }
    }
}
