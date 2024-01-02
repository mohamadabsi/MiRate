using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2201,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "\"<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\" > Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\" >Greetings،\r\n    <p>Kindly be informed that the company profile will be suspended due to the near expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to update this information.\r\n</p> \r\n            </h3>\"", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>يرجى العلم أنه سيتم تعليق الملف التعريفي للشركة بسبب قرب انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.</p> \r\n            </h3>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2201,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "\"<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\"> Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n    <p>Kindly be informed that the company profile will be suspended due to the near expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to update this information.\r\n</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n    <p>يرجى العلم أنه سيتم تعليق الملف التعريفي للشركة بسبب قرب انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.</p> \r\n            </h3>\"" });
        }
    }
}
