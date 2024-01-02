using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixWordInTheTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2231,
                column: "HTMLAr",
                value: "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"");

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
                keyValue: 2241,
                column: "HTMLAr",
                value: "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2242,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشركة .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2231,
                column: "HTMLAr",
                value: "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2232,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \r\n \"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2241,
                column: "HTMLAr",
                value: "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2242,
                column: "HTMLAr",
                value: "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \"");
        }
    }
}
